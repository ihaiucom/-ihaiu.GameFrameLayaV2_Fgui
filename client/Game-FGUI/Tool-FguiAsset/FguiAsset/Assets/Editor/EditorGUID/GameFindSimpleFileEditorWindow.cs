//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using UnityEditor;
//using UnityEngine;
///** 
//* ==============================================================================
//*  @Author      	曾峰(zengfeng75@qq.com) 
//*  @Web      		http://blog.ihaiu.com
//*  @CreateTime      5/15/2018 10:05:03 AM
//*  @Description:    
//* ==============================================================================
//*/
//namespace Games
//{
//    /// <summary>
//    /// 查找相同的文件
//    /// </summary>
//    public class GameFindSimpleFileEditorWindow : EditorWindow
//    {

//        public static GameFindSimpleFileEditorWindow window;
//        public static void Open()
//        {
//            if (window == null)
//            {
//                window = EditorWindow.GetWindow<GameFindSimpleFileEditorWindow>("查找相同的文件");
//                window.minSize = new Vector2(600, 500);
//            }
//            window.Show();
//        }


//        private string folderStr =
//@"Assets/GameArt/UISprite
//Assets/GameArt/UITexture";

//        List<List<FileData>> list = new List<List<FileData>>();
//        Dictionary<int, bool> isSetDict = new Dictionary<int, bool>();

//        private bool fold_find = true;
//        private void OnGUI()
//        {

//            GUILayout.Space(20);
//            fold_find = EditorGUILayout.Foldout(fold_find, "查找");
//            if (fold_find)
//            {
//                DrawFind();
//            }


//            GUILayout.Space(30);

//            DrawList();
//        }

//        private void DrawFind()
//        {
//            EditorGUILayout.BeginVertical(HStyle.boxMarginLeftStyle);

//            GUILayout.Box("资源目录：(用'换行'分隔)");
//            folderStr = GUILayout.TextArea(folderStr, 500, GUILayout.MinHeight(50));
//            folderStr = folderStr.Trim();




//            GUILayout.Space(20);

//            if (GUILayout.Button("查找", GUILayout.Height(50)))
//            {
//                Find();
//            }


//            if (GUILayout.Button("打开 清除没用被用的资源 窗口", GUILayout.Height(30)))
//            {
//                GameGUIDClearNoUseEditorWindow.Open();
//            }

//            EditorGUILayout.EndVertical();

//        }


//        Vector2 scroolPosition = Vector2.zero;
//        void DrawList()
//        {

//            DrawItemHead();
//            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
//            for (int i = 0; i < list.Count; i++)
//            {
//                DrawItem(i, list[i]);
//            }
//            EditorGUILayout.EndScrollView();
//        }


//        void DrawItemHead()
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(160), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(500), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("引用次数", HStyle.labelTableHeadStyle, GUILayout.Width(width), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private void DrawItem(int index, List<FileData> md5files)
//        {

//            int width = 100;
//            int height = 25;

//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            if(isSetDict.ContainsKey(index) && isSetDict[index])
//            {
//                GUILayout.Label("已设置",  GUILayout.Width(60), GUILayout.Height(height));
//            }

//            EditorGUILayout.BeginVertical();
//            for (int i = 0; i < md5files.Count; i ++)
//            {

//                EditorGUILayout.BeginHorizontal();
//                FileData file = md5files[i];

//                if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//                {
//                    Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.path);
//                }


//                if (GUILayout.Button("GUID旧资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//                {
//                    GUIDRefReplaceWindow.SetGUIDOld(file.path);
//                }

//                if (GUILayout.Button("GUID新资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//                {
//                    GUIDRefReplaceWindow.SetGUIDNew(file.path);
//                }



//                if (GUILayout.Button("设为主资源", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//                {
//                    if (GameGUIDClearNoUseEditorWindow.window != null)
//                    {
//                        SetMainRes(index, md5files, file);
//                    }
//                    else
//                    {
//                        this.ShowNotification(new GUIContent("先去打开\"清除没用的资源面板\"点击查找"));
//                    }

//                }


//                if (GUILayout.Button("引用详情", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//                {
//                    if (GameGUIDClearNoUseEditorWindow.window != null)
//                    {
//                        GameGUIDClearNoUseEditorWindow.window.OpenDetail(file.guid);
//                    }
//                    else
//                    {
//                        this.ShowNotification(new GUIContent("先去打开\"清除没用的资源面板\"点击查找"));
//                    }
//                }



//                GUILayout.Space(10);
//                string refNumStr = "--";
//                if(GameGUIDClearNoUseEditorWindow.window != null)
//                {
//                    refNumStr = GameGUIDClearNoUseEditorWindow.window.GetRefNumStr(file.guid);
//                }
//                GUILayout.Label(refNumStr, GUILayout.Width(width), GUILayout.Height(height));

//                GUILayout.Space(10);
//                GUILayout.Label(file.path, GUILayout.Height(height));
//                EditorGUILayout.EndHorizontal();
//            }
//            EditorGUILayout.EndVertical();


//            EditorGUILayout.EndHorizontal();
//        }

//        private void SetMainRes(int index, List<FileData> md5files, FileData main)
//        {
//            foreach(FileData item in md5files)
//            {
//                if (item == main)
//                    continue;

//                CaheFile file = GameGUIDClearNoUseEditorWindow.window.GetClearFile(item.guid);

//                foreach(CaheFile refFile in file.refList)
//                {
//                    var content = File.ReadAllText(refFile.filename);
//                    if (Regex.IsMatch(content, item.guid))
//                    {
//                        Debug.Log(refFile.filename, AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(refFile.filename));

//                        content = content.Replace(item.guid, main.guid);
//                        File.WriteAllText(refFile.filename, content);
//                    }
//                }
//            }


//            isSetDict[index] = true;
//        }


//        private void Find()
//        {

//            fileDict = new Dictionary<string, FileData>();
//            md5Dict = new Dictionary<string, List<FileData>>();
//            isSetDict.Clear();

//            string[] files;

//            // 查找资源目录
//            string[] folders = folderStr.Split('\n');
//            for (int i = 0; i < folders.Length; i++)
//            {
//                string folder = folders[i];
//                folder = folder.Trim();

//                if (string.IsNullOrEmpty(folder))
//                    continue;

//                files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => Path.GetExtension(s).ToLower() != ".meta").ToArray();

//                GenerateFiles(files);
//            }


//            list.Clear();

//            foreach (var kvp in md5Dict)
//            {
//                if (kvp.Value.Count > 1)
//                {
//                    list.Add(kvp.Value);
//                }
//            }

//            for(int i = 0; i < list.Count; i ++)
//            {
//                for(int j = 0; j < list[i].Count; j ++)
//                {
//                    list[i][j].guid = AssetDatabase.AssetPathToGUID(list[i][j].path);
//                }
//            }
//        }


//        Dictionary<string, FileData> fileDict = new Dictionary<string, FileData>();
//        Dictionary<string, List<FileData>> md5Dict = new Dictionary<string, List<FileData>>();
//        void GenerateFiles(string[] files)
//        {


//            for (int i = 0; i < files.Length; i++)
//            {
//                EditorUtility.DisplayProgressBar("查找相同的文件", files[i], i * 1f / files.Length);
//                FileData file = new FileData();
//                file.path = files[i];
//                file.md5 = PathUtil.md5file(file.path);

//                fileDict.Add(file.path, file);

//                List<FileData> list = null;
//                if(md5Dict.ContainsKey(file.md5))
//                {
//                    list = md5Dict[file.md5];
//                }
//                else
//                {
//                    list = md5Dict[file.md5] = new List<FileData>();
//                }

//                list.Add(file);
//            }

//            EditorUtility.ClearProgressBar();



//        }


//        public class FileData
//        {
//            public string guid;
//            public string path;
//            public string md5;
//        }

//    }
//}
