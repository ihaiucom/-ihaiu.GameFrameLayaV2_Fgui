//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;
///** 
//* ==============================================================================
//*  @Author      	曾峰(zengfeng75@qq.com) 
//*  @Web      		http://blog.ihaiu.com
//*  @CreateTime      5/14/2018 2:35:20 PM
//*  @Description:    
//* ==============================================================================
//*/
//namespace Games
//{
//    /// <summary>
//    /// 查找资源在场景中引用的详情
//    /// </summary>
//    public class GameGUIDRefFindInSceneEditorWindow : EditorWindow
//    {

//        public static GameGUIDRefFindInSceneEditorWindow window;
//        public static GameGUIDRefFindInSceneEditorWindow Open()
//        {
//            if (window == null)
//            {
//                window = EditorWindow.GetWindow<GameGUIDRefFindInSceneEditorWindow>("场景引用详情");
//                window.minSize = new Vector2(600, 500);
//            }
//            window.Show();
//            window.Repaint();
//            return window;
//        }

//        [UnityEditor.MenuItem("Assets/查看场景引用详情")]
//        public static void OpenSelect()
//        {
//            Open();
//            window.SetObject(Selection.activeObject);
//        }

//        public static void Open(string path)
//        {
//            Open();
//            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
//            window.SetObject(obj);
//        }


//        public static void Open(UnityEngine.Object obj)
//        {
//            Open();
//            window.SetObject(obj);
//        }

//        private UnityEngine.Object obj = null;
//        private UnityEngine.Object objLast = null;

//        public void SetObject(UnityEngine.Object obj)
//        {
//            this.obj = obj;
//            Repaint();
//        }

//        private List<RefData> list = new List<RefData>();
//        private Vector2 scroolPosition = Vector2.zero;
//        private void OnGUI()
//        {
//            obj = EditorGUILayout.ObjectField(obj, obj.GetType());

//            if (obj != objLast)
//            {
//                objLast = obj;
//                list = Find(obj);
//            }


//            if (GUILayout.Button("刷新", GUILayout.Height(30)))
//            {
//                list = Find(obj);
//            }



//            GUILayout.Space(20);
//            DrawUseItemHead(list);
//            scroolPosition = EditorGUILayout.BeginScrollView(scroolPosition);
//            for (int i = 0; i < list.Count; i++)
//            {
//                DrawUseItem(i, list[i]);
//            }
//            EditorGUILayout.EndScrollView();


//        }


//        void DrawUseItemHead(List<RefData> list)
//        {
//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);
//            GUILayout.Label("操作", HStyle.labelTableHeadStyle, GUILayout.Width(60), GUILayout.Height(height));
//            if (GUILayout.Button("↑", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((RefData a, RefData b) => { return a.path.CompareTo(b.path); });
//            }

//            if (GUILayout.Button("↓", HStyle.boxMiddleCenterStyle, GUILayout.Width(20), GUILayout.Height(height)))
//            {
//                list.Sort((RefData a, RefData b) => { return b.path.CompareTo(a.path); });
//            }
//            GUILayout.Space(10);

//            GUILayout.Label("Index", HStyle.labelTableHeadStyle, GUILayout.Width(100), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("组件名称", HStyle.labelTableHeadStyle, GUILayout.Width(300), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("成员变量", HStyle.labelTableHeadStyle, GUILayout.Width(200), GUILayout.Height(height));
//            GUILayout.Space(10);

//            GUILayout.Label("场景路径", HStyle.labelTableHeadStyle, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private void DrawUseItem(int index, RefData file)
//        {

//            int width = 100;
//            int height = 25;
//            EditorGUILayout.BeginHorizontal(HStyle.boxTableHeadStyle);



//            if (GUILayout.Button("选中", HStyle.boxMiddleCenterStyle, GUILayout.Width(100), GUILayout.Height(height)))
//            {
//                Selection.activeObject = file.component.transform;
//            }



//            GUILayout.Space(10);
//            GUILayout.Label(index.ToString(), HStyle.labelMiddleCenterStyle, GUILayout.Width(width), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.component.ToString(), GUILayout.Width(300), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.menberName, GUILayout.Width(200), GUILayout.Height(height));

//            GUILayout.Space(10);
//            GUILayout.Label(file.path, GUILayout.Height(height));
//            GUILayout.Space(10);

//            EditorGUILayout.EndHorizontal();
//        }


//        private List<RefData> Find(UnityEngine.Object obj)
//        {
//            List<RefData> reflist = new List<RefData>();
//            List<UnityEngine.Object> objectList = new List<UnityEngine.Object>();

//            string path = AssetDatabase.GetAssetPath(obj);
//            if(!string.IsNullOrEmpty(path))
//            {
//                UnityEngine.Object[] objects = AssetDatabase.LoadAllAssetsAtPath(path);
//                if(objects.Length > 0)
//                {
//                    objectList = new List<UnityEngine.Object>(objects);
//                }
//            }

//            Type imageType = typeof(UnityEngine.UI.Image);

//            List<Type> igoneTypes = new List<Type>(new Type[] { typeof(Transform), typeof(RectTransform), typeof(GameObject) });

//            GameObject[] roots =  SceneManager.GetActiveScene().GetRootGameObjects();
//            foreach(GameObject root in roots)
//            {
//                Component[] components = root.GetComponentsInChildren<Component>();
//                foreach(Component component in components)
//                {

//                    Type t = component.GetType();
//                    if (igoneTypes.Contains(t))
//                        continue;


//                    SerializedObject serializedObject = new UnityEditor.SerializedObject(component);

//                    SerializedProperty it = serializedObject.GetIterator();

//                    Debug.Log(component);
//                    while (it.NextVisible(true))
//                    { 
//                        //Debug.Log("-- " + it.name + "  objectReferenceValue=" + it.objectReferenceValue + "  propertyType=" + it.propertyType + "  propertyPath=" + it.propertyPath + "  isArray=" + it.isArray + "  hasChildren=" + it.hasChildren);

//                        if(it.propertyType == SerializedPropertyType.ObjectReference)
//                        {
//                            if (objectList.Contains(it.objectReferenceValue))
//                            {
//                                RefData data = new RefData();
//                                data.component = component;
//                                data.path = FullPathOf(component, null);
//                                data.menberName = it.propertyPath;
//                                reflist.Add(data);
//                            }
//                            else if(it.objectReferenceValue != null && it.hasChildren)
//                            {
//                                string valPath = AssetDatabase.GetAssetPath(it.objectReferenceValue);
//                                if(valPath != null)
//                                {
//                                    List<string> dependencies = new List<string>( AssetDatabase.GetDependencies(valPath));
//                                    if(dependencies.IndexOf(path) != -1)
//                                    {
//                                        RefData data = new RefData();
//                                        data.component = component;
//                                        data.path = FullPathOf(component, null);
//                                        data.menberName = it.propertyPath;
//                                        reflist.Add(data);
//                                    }
//                                }
//                            }

                            
//                        }

//                        //if(it.isArray)
//                        //{
//                        //    for (int i = 0; i < it.arraySize; i++)
//                        //    {
//                        //        SerializedProperty child = it.GetArrayElementAtIndex(i);

//                        //        Debug.Log("-- -- " + it.name + " ["+ i + "] "  + "  child=" + child .name + "  rectValue=" + child.rectValue + "  propertyType=" + it.propertyType + "  propertyPath=" + it.propertyPath + "  isArray=" + it.isArray + "  hasChildren=" + it.hasChildren);
//                        //    }
//                        //}
//                    }
//                    continue;




//                    //FieldInfo[] fields = t.GetFields();

//                    //foreach (FieldInfo info in fields)
//                    //{
//                    //    //Debug.Log(info.FieldType.IsArray);
//                    //    UnityEngine.Object val = info.GetValue(component) as UnityEngine.Object;
//                    //    if (val != null && objectList.Contains(val))
//                    //    {
//                    //        RefData data = new RefData();
//                    //        data.component = component;
//                    //        data.path = FullPathOf(component, null);
//                    //        data.menberName = info.Name;
//                    //        reflist.Add(data);

//                    //        Debug.Log(info.Name + "     " + component);
//                    //    }
//                    //    else if (info.FieldType.IsArray)
//                    //    {
//                    //        UnityEngine.Object[] arr = info.GetValue(component) as UnityEngine.Object[];
//                    //        if(arr != null)
//                    //        {
//                    //            for (int i = 0; i < arr.Length; i++)
//                    //            {
//                    //                if (arr[i] != null && objectList.Contains(arr[i]))
//                    //                {
//                    //                    RefData data = new RefData();
//                    //                    data.component = component;
//                    //                    data.path = FullPathOf(component, null);
//                    //                    data.menberName = info.Name + "[" + i + "]";
//                    //                    reflist.Add(data);

//                    //                    Debug.Log("[Array] " + info.Name + "     " + component);
//                    //                }
//                    //            }
//                    //        }
//                    //    }
//                    //    else if(info.FieldType.IsGenericType)
//                    //    {
//                    //       var list = info.GetValue(component) as IList;
//                    //        if (list != null)
//                    //        {
//                    //            for (int i = 0; i < list.Count; i++)
//                    //            {
//                    //                if (list[i] != null && objectList.Contains((UnityEngine.Object) list[i]))
//                    //                {
//                    //                    RefData data = new RefData();
//                    //                    data.component = component;
//                    //                    data.path = FullPathOf(component, null);
//                    //                    data.menberName = info.Name + "[" + i + "]";
//                    //                    reflist.Add(data);

//                    //                    Debug.Log("[List] " + info.Name + "     " + component);
//                    //                }
//                    //            }
//                    //        }

//                    //    }
//                    //}

//                    //PropertyInfo[] setters = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly );
//                    //foreach (PropertyInfo info in setters)
//                    //{
//                    //    //if (!info.CanWrite)
//                    //    //    continue;

//                    //    if(imageType == t)
//                    //    {
//                    //        if (info.Name == "overrideSprite" || info.Name == "mainTexture")
//                    //            continue;
//                    //    }

//                    //    UnityEngine.Object val = info.GetValue(component) as UnityEngine.Object;
//                    //    if (val != null)
//                    //    {
//                    //        if(objectList.Contains(val))
//                    //        {
//                    //            RefData data = new RefData();
//                    //            data.component = component;
//                    //            data.path = FullPathOf(component, null);
//                    //            data.menberName = info.Name;
//                    //            reflist.Add(data);
//                    //            Debug.Log(info.Name + "     " + component);
//                    //        }
//                    //        else
//                    //        {
//                    //            Material material = val as Material;
//                    //            if(material != null)
//                    //            {
//                    //                string materialPath = AssetDatabase.GetAssetPath(material);
//                    //                if(string.IsNullOrEmpty(materialPath))
//                    //                {
//                    //                    string[] dependencies = AssetDatabase.GetDependencies(materialPath);
//                    //                    if(dependencies.Contains(path))
//                    //                    {
//                    //                        RefData data = new RefData();
//                    //                        data.component = component;
//                    //                        data.path = FullPathOf(component, null);
//                    //                        data.menberName = info.Name;
//                    //                        reflist.Add(data);
//                    //                    }
//                    //                }
//                    //            }
//                    //        }
//                    //    }
//                    //    else if (info.PropertyType.IsArray)
//                    //    {
//                    //        UnityEngine.Object[] arr = info.GetValue(component) as UnityEngine.Object[];
//                    //        if (arr != null)
//                    //        {
//                    //            for (int i = 0; i < arr.Length; i++)
//                    //            {
//                    //                if (arr[i] != null && objectList.Contains(arr[i]))
//                    //                {

//                    //                    RefData data = new RefData();
//                    //                    data.component = component;
//                    //                    data.path = FullPathOf(component, null);
//                    //                    data.menberName = info.Name + "[" + i + "]";
//                    //                    reflist.Add(data);

//                    //                    Debug.Log("[Array] " + info.Name + "     " + component);
//                    //                }
//                    //            }
//                    //        }
//                    //    }
//                    //    else if (info.PropertyType.IsGenericType)
//                    //    {
//                    //        var list = info.GetValue(component) as IList;
//                    //        if (list != null)
//                    //        {
//                    //            for (int i = 0; i < list.Count; i++)
//                    //            {
//                    //                if (list[i] != null && objectList.Contains((UnityEngine.Object)list[i]))
//                    //                {
//                    //                    RefData data = new RefData();
//                    //                    data.component = component;
//                    //                    data.path = FullPathOf(component, null);
//                    //                    data.menberName = info.Name + "[" + i + "]";
//                    //                    reflist.Add(data);

//                    //                    Debug.Log("[List] " + info.Name + "     " + component);
//                    //                }
//                    //            }
//                    //        }
//                    //    }
//                    //}

//                }
//            }
//            return reflist;


//        }


//        public static string FullPathOf(Component comp, Transform root)
//        {
//            var path = "";
//            var curTrans = comp.transform;
//            while (curTrans != null)
//            {
//                if (curTrans == root)
//                    break;
//                if (curTrans == comp.transform)
//                    path = curTrans.name;
//                else
//                    path = curTrans.name + "/" + path;

//                curTrans = curTrans.parent;

//            }
//            return path;
//        }
//    }





//    public class RefData
//    {
//        public string path;
//        public Component component;
//        public String menberName;
//    }

//}
