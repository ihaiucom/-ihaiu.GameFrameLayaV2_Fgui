//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using UnityEditor;
//using UnityEngine;
///** 
//* ==============================================================================
//*  @Author      	曾峰(zengfeng75@qq.com) 
//*  @Web      		http://blog.ihaiu.com
//*  @CreateTime      5/11/2018 4:31:14 PM
//*  @Description:    
//* ==============================================================================
//*/
//namespace Games
//{
//    /// <summary>
//    /// 清除没有被用的资源编辑器窗口
//    /// </summary>
//    public class GameGUIDClearNoUseEditorWindow_List
//    {
//        public enum TabType
//        {
//            [HelpAttribute("无引用列表")]
//            NouseList,
//            [HelpAttribute("引用列表")]
//            UseList,
//            [HelpAttribute("过滤")]
//            Filter,
//        }

//        static HGUI.TabGroupData<TabType> _tabGroupData;
//        static HGUI.TabGroupData<TabType> tabGroupData
//        {
//            get
//            {
//                if (_tabGroupData == null)
//                {
//                    _tabGroupData = new HGUI.TabGroupData<TabType>();
//                    _tabGroupData.AddTab("无引用列表", TabType.NouseList);
//                    _tabGroupData.AddTab("引用列表", TabType.UseList);
//                    _tabGroupData.AddTab("过滤", TabType.Filter);

//                    _tabGroupData.SetSelect(TabType.NouseList);
//                }
//                return _tabGroupData;
//            }
//        }


//        private TabType tabType;

//        private Vector2 scroolPosition = Vector2.zero;
//        private bool isDraw = false;

//        private List<CaheFile> nouseList = new List<CaheFile>();
//        private List<CaheFile> useList = new List<CaheFile>();

//        public void SetList(List<CaheFile> nouseList, List<CaheFile> useList)
//        {
//            this.nouseList = nouseList;
//            this.useList = useList;
//            this.filterTextLast = "";
//            this.isDraw = true;
//        }

//        public void OnGUI()
//        {
//            if (!isDraw) return;

//            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);
//            TabType tabType = HGUI.TabGroup<TabType>(tabGroupData);
//            switch (tabType)
//            {
//                case TabType.NouseList:
//                    DrawNouseList(nouseList);
//                    break;
//                case TabType.UseList:
//                    DrawUseList(useList);
//                    break;
//                case TabType.Filter:
//                    DrawFilter();
//                    break;
//            }
//            EditorGUILayout.EndVertical();
//        }

//        private void DrawNouseList(List<CaheFile> list)
//        {
//            DrawNouseItemHead(list);
//            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
//            for (int i = 0; i < list.Count; i ++)
//            {
//                DrawNouseItem(i, list[i]);
//            }
//            EditorGUILayout.EndScrollView();
//            DrawNuseItemTool(list);
//        }


//        private void DrawUseList(List<CaheFile> list)
//        {
//            DrawUseItemHead(list);
//            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
//            for (int i = 0; i < list.Count; i++)
//            {
//                DrawUseItem(i, list[i]);
//            }
//            EditorGUILayout.EndScrollView();

//        }

//        private void DrawNuseItemTool(List<CaheFile> list)
//        {
//            EditorGUILayout.BeginHorizontal();
//            if (GUILayout.Button("全选", GUILayout.Width(100), GUILayout.Height(30)))
//            {
//                for(int i = 0; i < list.Count; i ++)
//                {
//                    list[i].isSelected = true;
//                }
//            }


//            if (GUILayout.Button("反选", GUILayout.Width(100), GUILayout.Height(30)))
//            {
//                for (int i = 0; i < list.Count; i++)
//                {
//                    list[i].isSelected = !list[i].isSelected;
//                }
//            }

//            if (GUILayout.Button("删除选中的", GUILayout.Width(100), GUILayout.Height(30)))
//            {

//                for (int i = 0; i < list.Count; i++)
//                {
//                    CaheFile file = list[i];
//                    if (file.isSelected)
//                    {
//                        if (File.Exists(file.filename))
//                            File.Delete(file.filename);
//                    }
//                }

//                AssetDatabase.Refresh();
//            }
//            EditorGUILayout.EndHorizontal();
//        }

//        void DrawNouseItemHead(List<CaheFile> list)
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(230), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
//            GUILayout.Space(10);

//            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((CaheFile a, CaheFile b) => { return a.filename.CompareTo(b.filename); });
//            }

//            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((CaheFile a, CaheFile b) => { return b.filename.CompareTo(a.filename); });
//            }
//            GUILayout.Label("文件", HStyle.labelTableHeadStyle,  GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }

//        private void DrawNouseItem(int index, CaheFile file)
//        {

//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);

//            file.isSelected = GUILayout.Toggle(file.isSelected, "", GUILayout.Width(30));


//            if (GUILayout.Button("删除", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                if (file.isSelected)
//                {
//                    if (File.Exists(file.filename))
//                        File.Delete(file.filename);
//                }
//                AssetDatabase.Refresh();
//            }


//            if (GUILayout.Button("选中资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.filename);
//            }


//            GUILayout.Space(10);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.filename, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        void DrawUseItemHead(List<CaheFile> list)
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(200), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("引用次数", HStyle.labelTableHeadStyle, GUILayout.Width(width), GUILayout.Height(height));
//            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                useList.Sort((CaheFile a, CaheFile b) => { return a.refList.Count.CompareTo(b.refList.Count); });
//            }

//            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                useList.Sort((CaheFile a, CaheFile b) => { return b.refList.Count.CompareTo(a.refList.Count); });
//            }
//            GUILayout.Space(10);

//            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((CaheFile a, CaheFile b) => { return a.filename.CompareTo(b.filename); });
//            }

//            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((CaheFile a, CaheFile b) => { return b.filename.CompareTo(a.filename); });
//            }
//            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private void DrawUseItem(int index, CaheFile file)
//        {

//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);

//            if (GUILayout.Button("依赖详情", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                GameGUIDRefDetailsEditorWindow.Open(file);
//            }


//            if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.filename);
//            }


//            GUILayout.Space(10);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.refList.Count + "", HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.filename, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }

//        private string filterText = "";
//        private string filterTextLast = "";
//        private List<CaheFile> nouseFilterList = new List<CaheFile>();
//        private List<CaheFile> useFilterList = new List<CaheFile>();
//        private bool nouseFilterVisable = true;
//        private bool useFilterVisable = true;
//        private void DrawFilter()
//        {
//            GUILayout.Space(10);
//            filterText = GUILayout.TextField(filterText);

//            GUILayout.Space(10);
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            nouseFilterVisable = GUILayout.Toggle(nouseFilterVisable, "无引用");
//            useFilterVisable = GUILayout.Toggle(useFilterVisable, "有引用");
//            EditorGUILayout.EndHorizontal();
//            GUILayout.Space(10);

//            if (filterText != filterTextLast)
//            {
//                string text = filterText.ToLower();
//                nouseFilterList.Clear();
//                for (int i = 0; i < nouseList.Count; i ++)
//                {
//                    CaheFile file = nouseList[i];
//                    if(Path.GetFileNameWithoutExtension(file.filename).ToLower().IndexOf(text) != -1)
//                    {
//                        nouseFilterList.Add(file);
//                    }
//                }


//                useFilterList.Clear();
//                for (int i = 0; i < useList.Count; i++)
//                {
//                    CaheFile file = useList[i];
//                    if (Path.GetFileNameWithoutExtension(file.filename).ToLower().IndexOf(text) != -1)
//                    {
//                        useFilterList.Add(file);
//                    }
//                }
//            }


//            nouseFilterVisable = EditorGUILayout.Foldout(nouseFilterVisable, "无引用");

//            if (nouseFilterVisable)
//                DrawNouseList(nouseFilterList);

//            useFilterVisable = EditorGUILayout.Foldout(useFilterVisable, "有引用");
//            if (useFilterVisable)
//                DrawUseList(useFilterList);
//        }





//    }
//}
