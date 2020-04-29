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
//    public class GameGUIDClearNoUseEditorWindow : EditorWindow
//    {
//        public static GameGUIDClearNoUseEditorWindow window;
//        public static void Open()
//        {
//            if (window == null)
//            {
//                window = EditorWindow.GetWindow<GameGUIDClearNoUseEditorWindow>("清除没有被用的资源编辑器窗口");
//                window.minSize = new Vector2(600, 500);
//            }
//            window.Show();
//        }


//        public enum TabType
//        {
//            [HelpAttribute("UI图片")]
//            UIImage,
//        }

//        static HGUI.TabGroupData<TabType> _tabGroupData;
//        static HGUI.TabGroupData<TabType> tabGroupData
//        {
//            get
//            {
//                if (_tabGroupData == null)
//                {
//                    _tabGroupData = new HGUI.TabGroupData<TabType>();
//                    _tabGroupData.AddTab("UI图片", TabType.UIImage);

//                    _tabGroupData.SetSelect(TabType.UIImage);
//                }
//                return _tabGroupData;
//            }
//        }


//        private TabType tabType;

//        private string clearFolderStr = 
//@"Assets/GameArt/UISprite
//Assets/GameArt/UITexture";


//        private string refFolderStr =
//@"Assets/GameArt/UIPrefab
//Assets/Game/Scenes
//Assets/Game/Resources/PrefabUI";

//        private GameGUIDClearNoUseEditorWindow_List listView = new GameGUIDClearNoUseEditorWindow_List();


//        private bool fold_find = true;
//        private void OnGUI()
//        {
//            if (window == null)
//                window = this;

//            TabType tabType = HGUI.TabGroup<TabType>(tabGroupData);
//            switch(tabType)
//            {
//                case TabType.UIImage:

//                    break;
//            }

//            GUILayout.Space(20);
//            fold_find = EditorGUILayout.Foldout(fold_find, "查找");
//            if (fold_find)
//            {

//                DrawFind();
//            }


//            GUILayout.Space(30);
//            listView.OnGUI();
//            GUILayout.Space(20);

//        }

//        private void DrawFind()
//        {
//            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);

//            GUILayout.Box("资源目录：(用'换行'分隔)");
//            clearFolderStr = GUILayout.TextArea(clearFolderStr, 500, GUILayout.MinHeight(50));
//            clearFolderStr = clearFolderStr.Trim();



//            GUILayout.Space(20);
//            GUILayout.Box("引用目录：(用'换行'分隔)");
//            refFolderStr = GUILayout.TextArea(refFolderStr, 500, GUILayout.MinHeight(50));
//            refFolderStr = refFolderStr.Trim();


//            GUILayout.Space(20);

//            if (GUILayout.Button("查找", GUILayout.Height(50)))
//            {
//                Find();
//            }

//            EditorGUILayout.EndVertical();


//        }

//        private Dictionary<string, CaheFile> clearDict = new Dictionary<string, CaheFile>();

//        public string GetRefNumStr(string guid)
//        {
//            if(clearDict.ContainsKey(guid))
//            {
//                return clearDict[guid].refList.Count.ToString();
//            }
//            return "--";
//        }

//        public void OpenDetail(string guid)
//        {
//            if (clearDict.ContainsKey(guid))
//            {
//                GameGUIDRefDetailsEditorWindow.Open(clearDict[guid]);
//            }
//        }

//        public CaheFile GetClearFile(string guid)
//        {
//            if (clearDict.ContainsKey(guid))
//            {
//                return clearDict[guid];
//            }
//            return null;
//        }

//        private void Find()
//        {
//            clearDict.Clear();
//            Dictionary<string, CaheFile> refDict = new Dictionary<string, CaheFile>();

//            string[] files;

//            // 查找资源目录
//            string[] folders = clearFolderStr.Split('\n');
//            for (int i = 0; i < folders.Length; i ++)
//            {
//                string folder = folders[i];
//                folder = folder.Trim();

//                if (string.IsNullOrEmpty(folder))
//                    continue;

//                files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => Path.GetExtension(s).ToLower() != ".meta").ToArray();
//                GenerateFiles(files, clearDict);
//            }

//            //查找引用目录
//            folders = refFolderStr.Split('\n');
//            for (int i = 0; i < folders.Length; i++)
//            {
//                string folder = folders[i];
//                folder = folder.Trim();

//                if (string.IsNullOrEmpty(folder))
//                    continue;

//                files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => Path.GetExtension(s).ToLower() != ".meta").ToArray();

//                GenerateFiles(files, refDict);
//            }

//            // 生成依赖
//            foreach(var kvp in refDict)
//            {
//                GenerateDependencies(kvp.Value, clearDict);
//            }

//            List<CaheFile> nouseList = new List<CaheFile>();
//            List<CaheFile> useList = new List<CaheFile>();
//            foreach (var kvp in clearDict)
//            {
//                CaheFile file = kvp.Value;
//                //Debug.Log(file.filename);

//                //foreach(CaheFile refFile in file.refList)
//                //{
//                //    Debug.Log(" " + refFile.filename);
//                //}

//                if(file.refList.Count == 0)
//                {
//                    nouseList.Add(file);
//                }
//                else
//                {
//                    useList.Add(file);
//                }
//            }

//            listView.SetList(nouseList, useList);

//        }


//        void GenerateFiles(string[] files, Dictionary<string, CaheFile> dict)
//        {

//            for (int i = 0; i < files.Length; i++)
//            {
//                CaheFile file = new CaheFile();
//                file.filename = files[i];
//                file.guid = AssetDatabase.AssetPathToGUID(file.filename);


//                if (dict.ContainsKey(file.guid))
//                {
//                    continue;
//                }
//                dict.Add(file.guid, file);
//            }
//        }

//        void GenerateDependencies(CaheFile file, Dictionary<string, CaheFile> clearDict)
//        {
//            string[] dependencies = AssetDatabase.GetDependencies(file.filename, false);
//            for (int i = 0; i < dependencies.Length; i++)
//            {
//                string guid = AssetDatabase.AssetPathToGUID(dependencies[i]);

//                if (guid == file.guid) continue;

//                if(clearDict.ContainsKey(guid))
//                {
//                    CaheFile def = clearDict[guid];
//                    def.AddRef(file);
//                }
//            }
//        }


//    }
//}
