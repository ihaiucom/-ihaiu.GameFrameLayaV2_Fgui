using Games;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      5/11/2018 4:31:14 PM
*  @Description:    
* ==============================================================================
*/
namespace EditorFguiAssets
{
    /// <summary>
    /// 清除没有被用的资源编辑器窗口
    /// </summary>
    public class FguiClearNoUseEditorWindow_List
    {
        public enum TabType
        {
            [HelpAttribute("无引用列表")]
            NouseList,
            [HelpAttribute("引用列表")]
            UseList,
            [HelpAttribute("过滤")]
            Filter,
        }

        static HGUI.TabGroupData<TabType> _tabGroupData;
        static HGUI.TabGroupData<TabType> tabGroupData
        {
            get
            {
                if (_tabGroupData == null)
                {
                    _tabGroupData = new HGUI.TabGroupData<TabType>();
                    _tabGroupData.AddTab("无引用列表", TabType.NouseList);
                    _tabGroupData.AddTab("引用列表", TabType.UseList);
                    _tabGroupData.AddTab("过滤", TabType.Filter);

                    _tabGroupData.SetSelect(TabType.NouseList);
                }
                return _tabGroupData;
            }
        }


        private TabType tabType;

        private Vector2 scroolPosition = Vector2.zero;
        private bool isDraw = false;

        private List<AssetData> nouseList = new List<AssetData>();
        private List<AssetData> useList = new List<AssetData>();

        public void SetList(List<AssetData> nouseList, List<AssetData> useList)
        {
            this.nouseList = nouseList;
            this.useList = useList;
            this.filterTextLast = "";
            this.isDraw = true;
        }

        public void OnGUI()
        {
            if (!isDraw) return;

            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);
            TabType tabType = HGUI.TabGroup<TabType>(tabGroupData);
            switch (tabType)
            {
                case TabType.NouseList:
                    DrawNouseList(nouseList);
                    break;
                case TabType.UseList:
                    DrawUseList(useList);
                    break;
                case TabType.Filter:
                    DrawFilter();
                    break;
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawNouseList(List<AssetData> list)
        {
            DrawNouseItemHead(list);
            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
            for (int i = 0; i < list.Count; i++)
            {
                DrawNouseItem(i, list[i]);
            }
            EditorGUILayout.EndScrollView();
            DrawNuseItemTool(list);
        }


        private void DrawUseList(List<AssetData> list)
        {
            DrawUseItemHead(list);
            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
            for (int i = 0; i < list.Count; i++)
            {
                DrawUseItem(i, list[i]);
            }
            EditorGUILayout.EndScrollView();

        }

        private void DrawNuseItemTool(List<AssetData> list)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("全选", GUILayout.Width(100), GUILayout.Height(30)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].isSelected = true;
                }
            }


            if (GUILayout.Button("反选", GUILayout.Width(100), GUILayout.Height(30)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].isSelected = !list[i].isSelected;
                }
            }

            if (GUILayout.Button("删除选中的", GUILayout.Width(100), GUILayout.Height(30)))
            {

                for (int i = 0; i < list.Count; i++)
                {
                    AssetData file = list[i];
                    if (file.isSelected)
                    {
                        file.package.RemoveImageXml(file);
                        file.package.RemoveResource(file);
                        if (File.Exists(file.pathForFull))
                            File.Delete(file.pathForFull);
                    }
                }

                //AssetDatabase.Refresh();
            }



            if (GUILayout.Button("删除选中 不包含设置导出的", GUILayout.Width(100), GUILayout.Height(30)))
            {

                for (int i = 0; i < list.Count; i++)
                {
                    AssetData file = list[i];
                    if (file.isSelected && !file.exported)
                    {
                        file.package.RemoveImageXml(file);
                        file.package.RemoveResource(file);
                        if (File.Exists(file.pathForFull))
                            File.Delete(file.pathForFull);
                    }
                }

                //AssetDatabase.Refresh();
            }
            EditorGUILayout.EndHorizontal();
        }

        void DrawNouseItemHead(List<AssetData> list)
        {
            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(430), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
            GUILayout.Space(10);

            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((Comparison<AssetData>)((AssetData a, AssetData b) => { return (int)a.pathForAssets.CompareTo((string)b.pathForAssets); }));
            }

            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((Comparison<AssetData>)((AssetData a, AssetData b) => { return (int)b.pathForAssets.CompareTo((string)a.pathForAssets); }));
            }
            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }

        private void DrawNouseItem(int index, AssetData file)
        {

            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);

            file.isSelected = GUILayout.Toggle(file.isSelected, "", GUILayout.Width(30));


            if (GUILayout.Button("删除", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
                file.package.RemoveImageXml(file);
                file.package.RemoveResource(file);

                if (File.Exists(file.pathForFull))
                    File.Delete(file.pathForFull);
                //AssetDatabase.Refresh();
            }


            if (GUILayout.Button("选中资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
                Shell.ShowInExplorer(file.pathForFull);
                //Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.pathForAssets);
            }

            if (GUILayout.Button("引用详情", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
                FguiRefDetailsEditorWindow.Open(file);
            }

            bool export = GUILayout.Toggle(file.exported, "是否导出", GUILayout.Width(100), GUILayout.Height(height));
            if (export != file.exported)
            {
                file.package.SetImageExport(file, export);
            }


            GUILayout.Space(10);
            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

            GUILayout.Space(10);
            GUILayout.Label(file.pathForAssets, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }


        void DrawUseItemHead(List<AssetData> list)
        {
            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(300), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("引用次数", HStyle.labelTableHeadStyle, GUILayout.Width(width), GUILayout.Height(height));
            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                useList.Sort((AssetData a, AssetData b) => { return a.beDependCount.CompareTo(b.beDependCount); });
            }

            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                useList.Sort((AssetData a, AssetData b) => { return b.beDependCount.CompareTo(a.beDependCount); });
            }
            GUILayout.Space(10);

            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((Comparison<AssetData>)((AssetData a, AssetData b) => { return (int)a.pathForAssets.CompareTo((string)b.pathForAssets); }));
            }

            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((Comparison<AssetData>)((AssetData a, AssetData b) => { return (int)b.pathForAssets.CompareTo((string)a.pathForAssets); }));
            }
            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }


        private void DrawUseItem(int index, AssetData file)
        {

            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);

            if (GUILayout.Button("依赖详情", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
                FguiRefDetailsEditorWindow.Open(file);
            }


            if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
                Shell.ShowInExplorer(file.pathForFull);
                //Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.pathForAssets);
            }

            bool export = GUILayout.Toggle(file.exported, "是否导出", GUILayout.Width(100), GUILayout.Height(height));
            if (export != file.exported)
            {
                file.package.SetImageExport(file, export);
            }


            GUILayout.Space(10);
            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

            GUILayout.Space(10);
            GUILayout.Label(file.beDependCount + "", HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

            GUILayout.Space(10);
            GUILayout.Label(file.pathForAssets, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }

        private string filterText = "";
        private string filterTextLast = "";
        private List<AssetData> nouseFilterList = new List<AssetData>();
        private List<AssetData> useFilterList = new List<AssetData>();
        private bool nouseFilterVisable = true;
        private bool useFilterVisable = true;
        private void DrawFilter()
        {
            GUILayout.Space(10);
            filterText = GUILayout.TextField(filterText);

            GUILayout.Space(10);
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            nouseFilterVisable = GUILayout.Toggle(nouseFilterVisable, "无引用");
            useFilterVisable = GUILayout.Toggle(useFilterVisable, "有引用");
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(10);

            if (filterText != filterTextLast)
            {
                string text = filterText.ToLower();
                nouseFilterList.Clear();
                for (int i = 0; i < nouseList.Count; i++)
                {
                    AssetData file = nouseList[i];
                    if (Path.GetFileNameWithoutExtension(file.pathForAssets).ToLower().IndexOf(text) != -1)
                    {
                        nouseFilterList.Add(file);
                    }
                }


                useFilterList.Clear();
                for (int i = 0; i < useList.Count; i++)
                {
                    AssetData file = useList[i];
                    if (Path.GetFileNameWithoutExtension(file.pathForAssets).ToLower().IndexOf(text) != -1)
                    {
                        useFilterList.Add(file);
                    }
                }
            }


            nouseFilterVisable = EditorGUILayout.Foldout(nouseFilterVisable, "无引用");

            if (nouseFilterVisable)
                DrawNouseList(nouseFilterList);

            useFilterVisable = EditorGUILayout.Foldout(useFilterVisable, "有引用");
            if (useFilterVisable)
                DrawUseList(useFilterList);
        }





    }
}
