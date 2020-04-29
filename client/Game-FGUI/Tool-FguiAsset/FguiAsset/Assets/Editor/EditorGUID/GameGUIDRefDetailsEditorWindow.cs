//using System;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
///** 
//* ==============================================================================
//*  @Author      	曾峰(zengfeng75@qq.com) 
//*  @Web      		http://blog.ihaiu.com
//*  @CreateTime      5/14/2018 10:39:49 AM
//*  @Description:    
//* ==============================================================================
//*/
//namespace Games
//{
//    /// <summary>
//    /// 引用详情
//    /// </summary>
//    public class GameGUIDRefDetailsEditorWindow : EditorWindow
//    {
//        public static GameGUIDRefDetailsEditorWindow window;
//        public static CaheFile file;
//        public static void Open(CaheFile file)
//        {
//            GameGUIDRefDetailsEditorWindow.file = file;

//            if (window == null)
//            {
//                window = EditorWindow.GetWindow<GameGUIDRefDetailsEditorWindow>("引用详情");
//                window.minSize = new Vector2(600, 500);
//            }
//            window.obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.filename);
//            window.Show();
//            window.Repaint();
//        }

//        private UnityEngine.Object obj = null;
//        private Vector2 scroolPosition = Vector2.zero;
//        private void OnGUI()
//        {
//            if(file == null)
//            {

//                GUILayout.Label("没有选择文件");
//                return;

//            }


//            EditorGUILayout.LabelField("文件", file.filename);

//            EditorGUILayout.ObjectField(obj, obj.GetType());


//            DrawUseItemHead(file.refList);
//            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
//            for (int i = 0; i < file.refList.Count; i++)
//            {
//                DrawUseItem(i, file.refList[i]);
//            }
//            EditorGUILayout.EndScrollView();

//            if (GUILayout.Button("添加所有的预设到场景", GUILayout.Height(30)))
//            {
//                for (int i = 0; i < file.refList.Count; i++)
//                {
//                    AddToScene(file.refList[i]);
//                }
//                GameGUIDRefFindInSceneEditorWindow.Open(obj);
//            }


//        }


//        void DrawUseItemHead(List<CaheFile> list)
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
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
//            GUILayout.Label("文件", HStyle.labelTableHeadStyle, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private void DrawUseItem(int index, CaheFile file)
//        {

//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);



//            if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(file.filename);
//            }


//            if (GUILayout.Button("添加到场景", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                AddToScene(file);
//                GameGUIDRefFindInSceneEditorWindow.Open(obj);
//            }


//            GUILayout.Space(10);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.filename, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }

//        private void AddToScene(CaheFile file)
//        {
//            GameObject canvas = GameObject.Find("Canvas");
//            Transform canvasTransform = null;
//            if (canvas != null)
//                canvasTransform = canvas.transform;

//            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file.filename);
//            if(prefab != null)
//            {
//                GameObject go = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(file.filename)) as GameObject;
//                if (canvasTransform != null && go.GetComponent<RectTransform>() != null)
//                    go.transform.SetParent(canvasTransform, false);
//            }
//        }

//    }
//}
