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
    public class FguiClearNoUseEditorWindow : EditorWindow
    {
        public static FguiClearNoUseEditorWindow window;
        public static void Open()
        {
            if (window == null)
            {
                window = EditorWindow.GetWindow<FguiClearNoUseEditorWindow>("清除没有被用的资源编辑器窗口");
                window.minSize = new Vector2(600, 500);
            }

            window.listView.SetList(FairyManager.Instance.nouseList, FairyManager.Instance.useList);
            window.Show();
        }


        public enum TabType
        {
            [HelpAttribute("UI图片")]
            UIImage,
        }

        static HGUI.TabGroupData<TabType> _tabGroupData;
        static HGUI.TabGroupData<TabType> tabGroupData
        {
            get
            {
                if (_tabGroupData == null)
                {
                    _tabGroupData = new HGUI.TabGroupData<TabType>();
                    _tabGroupData.AddTab("UI图片", TabType.UIImage);

                    _tabGroupData.SetSelect(TabType.UIImage);
                }
                return _tabGroupData;
            }
        }



        private FguiClearNoUseEditorWindow_List listView = new FguiClearNoUseEditorWindow_List();


        private bool fold_find = true;
        private void OnGUI()
        {
            if (window == null)
                window = this;


            GUILayout.Space(20);
            fold_find = EditorGUILayout.Foldout(fold_find, "查找");
            if (fold_find)
            {
                DrawFind();
            }


            GUILayout.Space(30);
            listView.OnGUI();
            GUILayout.Space(20);

        }

        private void DrawFind()
        {
            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);


            GUILayout.Space(20);

            if (GUILayout.Button("查找", GUILayout.Height(50)))
            {
                Find();
            }

            EditorGUILayout.EndVertical();
        }


        private void Find()
        {
            FairyManager.Instance.LoadProject(Setting.Options.fairyProject);
            FairyManager.Instance.GenerateMD5();
            listView.SetList(FairyManager.Instance.nouseList, FairyManager.Instance.useList);
        }




    }
}
