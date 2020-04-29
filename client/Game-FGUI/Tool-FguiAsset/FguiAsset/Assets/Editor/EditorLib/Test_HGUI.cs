using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 1:24:00 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{

    public class Test_HGUI : EditorWindow
    {
        public static Test_HGUI window;

        [MenuItem("Window/测试HGUI")]
        public static void Open()
        {
            window = EditorWindow.GetWindow<Test_HGUI>("测试HGUI");
            window.minSize = new Vector2(800, 500);
            window.Show();
        }

        Vector2 scrollPos;
        void OnGUI()
        {
            HGUI_TabGoup_Demo.Test();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            // 水平居中
            HGUI.BeginCenterHorizontal();
            GUILayout.Button("水平居中");
            GUILayout.Button("水平居中");
            HGUI.EndCenterHorizontal();


            // 垂直居中
            HGUI.BeginMiddleVertical(50);
            GUILayout.Button("垂直居中");
            GUILayout.Button("垂直居中");
            HGUI.EndMiddleVertical();


            GUILayout.BeginVertical(HStyle.boxModuleStyle);
            GUILayout.Button("boxModuleStyle");
            GUILayout.Button("boxModuleStyle");

            GUILayout.BeginVertical(HStyle.boxBarStyle);
            GUILayout.Button("boxBarStyle");
            GUILayout.Button("boxBarStyle");
            GUILayout.EndVertical();

            GUILayout.EndVertical();


            GUILayout.BeginVertical(HStyle.boxModuleStyle);
            GUILayout.TextField("textFieldStyle_Normal", HStyle.textFieldStyle_Normal);
            GUILayout.Space(10);
            GUILayout.TextField("textFieldStyle_Disable", HStyle.textFieldStyle_Disable);

            GUILayout.EndVertical();


            GUILayout.BeginVertical(HStyle.boxModuleStyle);
            EditorGUILayout.LabelField("labelCenterStyle", HStyle.labelMiddleCenterStyle, GUILayout.Width(150));
            GUILayout.Space(10);
            EditorGUILayout.LabelField("label<color=red>Rich</color>Style", HStyle.labelRichStyle, GUILayout.Width(150));

            GUILayout.EndVertical();


            EditorGUILayout.EndScrollView();
        }
    }
}
