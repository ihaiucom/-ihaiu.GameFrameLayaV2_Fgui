using Games;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      5/15/2018 10:05:03 AM
*  @Description:    
* ==============================================================================
*/
namespace EditorFguiAssets
{
    /// <summary>
    /// 查找相同的文件
    /// </summary>
    public class FguiSimpleFileEditorWindow : EditorWindow
    {

        public static FguiSimpleFileEditorWindow window;
        public static void Open()
        {
            if (window == null)
            {
                window = EditorWindow.GetWindow<FguiSimpleFileEditorWindow>("查找相同的文件");
                window.minSize = new Vector2(600, 500);
            }
            window.Show();
        }


        // 忽略 包名
        private string ignorePackageStr =
@"System
Sound
BlackSkin
__ResImageTmp
__Style";

        // 代码引用
        private string codeUsesStr = "";
//@"Common/guis/guis_cooperation/icon_reward_lv1_1.png
//Common/guis/guis_cooperation/icon_reward_lv1_2.png
//Common/guis/guis_cooperation/icon_reward_lv1_3.png
//Common/guis/guis_cooperation/icon_reward_lv2_1.png
//Common/guis/guis_cooperation/icon_reward_lv2_2.png
//Common/guis/guis_cooperation/icon_reward_lv2_3.png
//Common/guis/guis_cooperation/icon_reward_lv3_1.png
//Common/guis/guis_cooperation/icon_reward_lv3_2.png
//Common/guis/guis_cooperation/icon_reward_lv3_3.png
//Common/guis/guis_cooperation/icon_reward_lv4_1.png
//Common/guis/guis_cooperation/icon_reward_lv4_2.png
//Common/guis/guis_cooperation/icon_reward_lv4_3.png
//";

        List<List<AssetData>> list = new List<List<AssetData>>();
        Dictionary<int, bool> isSetDict = new Dictionary<int, bool>();

        private bool fold_find = true;
        private void OnGUI()
        {

            GUILayout.Space(20);
            fold_find = EditorGUILayout.Foldout(fold_find, "查找");
            if (fold_find)
            {
                DrawFind();
            }


            GUILayout.Space(30);

            DrawList();

            GUILayout.Space(30);
            DrawItemTool();
        }


        private void DrawItemTool()
        {
            EditorGUILayout.BeginHorizontal();
          

            if (GUILayout.Button("全部移至Common", GUILayout.Width(100), GUILayout.Height(30)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    List<AssetData> md5files = list[i];
                    foreach(AssetData assetData in md5files)
                    {
                        assetData.MoveToCommon();
                    }
                }
            }



            if (GUILayout.Button("优先使用Common", GUILayout.Width(100), GUILayout.Height(30)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    List<AssetData> md5files = list[i];
                    AssetData commonAsset = null;
                    foreach (AssetData assetData in md5files)
                    {
                        if(assetData.package.folderName == "Common")
                        {
                            if (commonAsset == null)
                                commonAsset = assetData;
                            else if (assetData.beDependCount > commonAsset.beDependCount)
                                commonAsset = assetData;

                        }
                    }

                    if (commonAsset != null)
                        SetMainRes(i, md5files, commonAsset);
                }
            }



            EditorGUILayout.EndHorizontal();
        }

        private void DrawFind()
        {
            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);

            GUILayout.Box("忽略包名：(用'换行'分隔)");
            ignorePackageStr = GUILayout.TextArea(ignorePackageStr, 500, GUILayout.MinHeight(50));
            ignorePackageStr = ignorePackageStr.Trim();
            GUILayout.Space(20);


            GUILayout.Box("代码引用：(用'换行'分隔)");
            codeUsesStr = GUILayout.TextArea(codeUsesStr, 500, GUILayout.MinHeight(50));
            codeUsesStr = codeUsesStr.Trim();
            GUILayout.Space(20);

            FairyManager.Instance.ignorePackageStr = ignorePackageStr;
            FairyManager.Instance.codeUsesStr = codeUsesStr;

            if (GUILayout.Button("查找", GUILayout.Height(50)))
            {
                Find();
            }


            if (GUILayout.Button("打开 清除没用被用的资源 窗口", GUILayout.Height(30)))
            {
                FguiClearNoUseEditorWindow.Open();
            }

            EditorGUILayout.EndVertical();

        }

        void Find()
        {
            FairyManager.Instance.LoadProject(Setting.Options.fairyProject);
            FairyManager.Instance.GenerateMD5();
            list = FairyManager.Instance.simpleMD5List;
            isSetDict.Clear();
        }


        Vector2 scroolPosition = Vector2.zero;
        void DrawList()
        {

            DrawItemHead();
            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
            for (int i = 0; i < list.Count; i++)
            {
                DrawItem(i, list[i]);
            }
            EditorGUILayout.EndScrollView();
        }


        void DrawItemHead()
        {
            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(160), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(300), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("引用次数", HStyle.labelTableHeadStyle, GUILayout.Width(width), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("是否设置为导出", HStyle.labelTableHeadStyle, GUILayout.Width(width), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }


        private void DrawItem(int index, List<AssetData> md5files)
        {

            int width = 100;
            int height = 25;

            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

            if (isSetDict.ContainsKey(index) && isSetDict[index])
            {
                GUILayout.Label("已设置", GUILayout.Width(60), GUILayout.Height(height));
            }

            EditorGUILayout.BeginVertical();
            for (int i = 0; i < md5files.Count; i++)
            {

                EditorGUILayout.BeginHorizontal();
                AssetData file = md5files[i];

                if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
                {
                    Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.path);
                }


                if (GUILayout.Button("设为主资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
                {

                    SetMainRes(index, md5files, file);

                }



                if (GUILayout.Button("移至 Common", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
                {
                    file.MoveToCommon();
                }


                if (GUILayout.Button("引用详情", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
                {
                    FguiRefDetailsEditorWindow.Open(file);
                }

                if (GUILayout.Button("打开 Common", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
                {
                    file.ShowInExplorerForCommon();
                }

                bool export = GUILayout.Toggle(file.exported, "是否导出", GUILayout.Width(100), GUILayout.Height(height));
                if(export != file.exported)
                {
                    file.package.SetImageExport(file, export);
                }



                GUILayout.Space(10);
                GUILayout.Label(file.beDependCount.ToString(), GUILayout.Width(width), GUILayout.Height(height));

                GUILayout.Space(10);
                GUILayout.Label(file.pathForAssets, GUILayout.Height(height));
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();


            EditorGUILayout.EndHorizontal();
        }

        private void SetMainRes(int index, List<AssetData> md5files, AssetData main)
        {
            foreach (AssetData item in md5files)
            {
                if (item == main)
                    continue;

                item.BeDependListReplace(main);

                item.package.SetImageExport(item, false);
            }

            main.package.SetImageExport(main, true);

            isSetDict[index] = true;
        }

    }
}
