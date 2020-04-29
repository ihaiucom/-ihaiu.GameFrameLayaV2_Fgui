//using System;
//using System.Collections.Generic;
//using System.IO;
//using UnityEditor;
//using UnityEngine;
///** 
//* ==============================================================================
//*  @Author      	曾峰(zengfeng75@qq.com) 
//*  @Web      		http://blog.ihaiu.com
//*  @CreateTime      5/15/2018 5:01:20 PM
//*  @Description:    
//* ==============================================================================
//*/
//namespace Games
//{
//    /// <summary>
//    /// 查找空的文件夹
//    /// </summary>
//    public class GameFindEmpyFolderEditorWindow : EditorWindow
//    {

//        public static GameFindEmpyFolderEditorWindow window;
//        public static void Open()
//        {
//            if (window == null)
//            {
//                window = EditorWindow.GetWindow<GameFindEmpyFolderEditorWindow>("查找空的文件夹");
//                window.minSize = new Vector2(600, 500);
//            }
//            window.Show();
//        }

//        private void OnGUI()
//        {

//            if (GUILayout.Button("查找", GUILayout.Height(50)))
//            {
//                Find();
//            }

//            DrawList();

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

//            DrawItemTool();

//            if(listWaitRemovet.Count > 0)
//            {
//                List<string> list2 = new List<string>();
//                List<bool> listSelected2 = new List<bool>();

//                for (int i = 0; i < list.Count; i++)
//                {
//                    if (listWaitRemovet.IndexOf(i) == -1)
//                    {
//                        list2.Add(list[i]);
//                        listSelected2.Add(listSelected[i]);
//                    }
//                }

//                list = list2;
//                listSelected = listSelected2;
//                listWaitRemovet.Clear();
//            }
                
//        }


//        private void DrawItemTool()
//        {
//            EditorGUILayout.BeginHorizontal();
//            if (GUILayout.Button("全选", GUILayout.Width(100), GUILayout.Height(30)))
//            {
//                for (int i = 0; i < listSelected.Count; i++)
//                {
//                    listSelected[i] = true;
//                }
//            }


//            if (GUILayout.Button("反选", GUILayout.Width(100), GUILayout.Height(30)))
//            {
//                for (int i = 0; i < listSelected.Count; i++)
//                {
//                    listSelected[i] = !listSelected[i];
//                }
//            }

//            if (GUILayout.Button("删除选中的", GUILayout.Width(100), GUILayout.Height(30)))
//            {

//                for (int i = 0; i < list.Count; i++)
//                {
                   
//                    if (listSelected[i])
//                    {
//                        if (Directory.Exists(list[i]))
//                            Directory.Delete(list[i]);

//                        listWaitRemovet.Add(i);
//                    }
//                }

//                AssetDatabase.Refresh();
//            }
//            EditorGUILayout.EndHorizontal();
//        }



//        void DrawItemHead()
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(130), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("路径", HStyle.labelTableHeadStyle, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private void DrawItem(int index, string path)
//        {

//            int width = 100;
//            int height = 25;

//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));


//            listSelected[index] = GUILayout.Toggle(listSelected[index], "", GUILayout.Width(30));


//            if (GUILayout.Button("删除", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                if(Directory.Exists(path))
//                {
//                    Directory.Delete(path);
//                    AssetDatabase.Refresh();
//                    listWaitRemovet.Add(index);
//                }
//            }


//            if (GUILayout.Button("打开", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                Shell.RevealInFinder(path);
//            }


//            GUILayout.Space(10);
//            GUILayout.Label(path, GUILayout.Height(height));


//            EditorGUILayout.EndHorizontal();
//        }

//        List<string> list = new List<string>();
//        List<bool> listSelected = new List<bool>();
//        List<int> listWaitRemovet = new List<int>();
//        private void Find()
//        {
//            string root = Application.dataPath;
//            root = root.Replace("\\", "/").Replace("/Assets", "/");


//            DirectoryInfo dir = Directory.CreateDirectory("Assets");

//            Dictionary<string, int> dict = new Dictionary<string, int>();
//            TraverseDirectory(dir, dict);

//            list.Clear();
//            listSelected.Clear();
//            listWaitRemovet.Clear();
//            foreach (var kvp in dict)
//            {
//                if(kvp.Value == 0)
//                {

//                    string path = kvp.Key;
//                    path = path.Replace("\\", "/").Replace(root, "");

//                    list.Add(path);
//                    listSelected.Add(false);
//                }

//            }
//        }

//        private void TraverseDirectory(DirectoryInfo dir, Dictionary<string, int> dict)
//        {
//            int num = dir.GetFiles().Length;

//            DirectoryInfo[] dirList = dir.GetDirectories();
//            num += dirList.Length;
//            foreach (DirectoryInfo item in dirList)
//            {
//                TraverseDirectory(item, dict);
//            }

//            dict.Add(dir.FullName, num);
//        }

//    }
//}
