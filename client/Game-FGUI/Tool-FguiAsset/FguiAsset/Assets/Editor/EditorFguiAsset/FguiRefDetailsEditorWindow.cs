using Games;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      5/14/2018 10:39:49 AM
*  @Description:    
* ==============================================================================
*/

namespace EditorFguiAssets
{
    /// <summary>
    /// 引用详情
    /// </summary>
    public class FguiRefDetailsEditorWindow : EditorWindow
    {
        public static FguiRefDetailsEditorWindow window;
        public static void Open(AssetData assetData)
        {

            if (window == null)
            {
                window = EditorWindow.GetWindow<FguiRefDetailsEditorWindow>("引用详情");
                window.minSize = new Vector2(600, 500);
            }
            window.assetData = assetData;
            window.Show();
            window.Repaint();
        }

        private AssetData assetData = null;
        private Vector2 scroolPosition = Vector2.zero;
        private void OnGUI()
        {
            if (assetData == null)
            {

                GUILayout.Label("没有选择文件");
                return;

            }


            EditorGUILayout.LabelField("文件", assetData.pathForAssets);

            switch(assetData.type)
            {
                case ResourceComponentType.image:
                    EditorTexture2D.Draw(assetData.texture);
                    break;
            }


            DrawUseItemHead(assetData.beDependList);
            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
            for (int i = 0; i < assetData.beDependList.Count; i++)
            {
                DrawUseItem(i, assetData.beDependList[i]);
            }
            EditorGUILayout.EndScrollView();

            //if (GUILayout.Button("添加所有的预设到场景", GUILayout.Height(30)))
            //{
            //    for (int i = 0; i < assetData.beDependList.Count; i++)
            //    {
            //        AddToScene(assetData.beDependList[i]);
            //    }
            //    GameGUIDRefFindInSceneEditorWindow.Open(assetData);
            //}


        }


        void DrawUseItemHead(List<AssetData> list)
        {
            int width = 100;
            int height = 25;
            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
            GUILayout.Space(10);

            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
            GUILayout.Space(10);

            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((AssetData a, AssetData b) => { return a.pathForAssets.CompareTo(b.pathForAssets); });
            }

            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
            {
                list.Sort((AssetData a, AssetData b) => { return b.pathForAssets.CompareTo(a.pathForAssets); });
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



            if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
            {
            }


            GUILayout.Space(10);
            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

            GUILayout.Space(10);
            GUILayout.Label(file.pathForAssets, GUILayout.Height(height));
            GUILayout.Space(10);

            EditorGUILayout.EndHorizontal();
        }

        private void AddToScene(AssetData file)
        {
            //GameObject canvas = GameObject.Find("Canvas");
            //Transform canvasTransform = null;
            //if (canvas != null)
            //    canvasTransform = canvas.transform;

            //GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file.filename);
            //if (prefab != null)
            //{
            //    GameObject go = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(file.filename)) as GameObject;
            //    if (canvasTransform != null && go.GetComponent<RectTransform>() != null)
            //        go.transform.SetParent(canvasTransform, false);
            //}
        }

    }
}
