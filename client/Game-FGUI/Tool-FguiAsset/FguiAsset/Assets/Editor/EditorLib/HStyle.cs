using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 10:16:10 AM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    /** 样式 */
    public partial class HStyle
    {
        private static GUIStyle _helpBox;
        public static GUIStyle helpBox
        {
            get
            {
#if UNITY_4_7

                GUIStyle style = new GUIStyle(EditorStyles.objectFieldThumb);
#else
                    GUIStyle style = new GUIStyle(EditorStyles.helpBox);
#endif
                return style;
            }
        }





        private static GUIStyle _textFieldStyle_Normal;
        public static GUIStyle textFieldStyle_Normal
        {
            get
            {
                if (_textFieldStyle_Normal == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.miniTextField);
                    _textFieldStyle_Normal = style;
                }
                return _textFieldStyle_Normal;
            }
        }


        private static GUIStyle _textFieldStyle_Disable;
        public static GUIStyle textFieldStyle_Disable
        {
            get
            {
                if (_textFieldStyle_Disable == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.miniTextField);
                    style.normal.textColor = Color.gray;
                    _textFieldStyle_Disable = style;
                }
                return _textFieldStyle_Disable;
            }
        }


        private static GUIStyle _labelCenterStyle;
        public static GUIStyle labelMiddleCenterStyle
        {
            get
            {

                if (_labelCenterStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleCenter;
                    style.fontSize = 16;

                    _labelCenterStyle = style;
                }
                return _labelCenterStyle;
            }
        }



        private static GUIStyle _labelMiddleRightStyle;
        public static GUIStyle labelMiddleRightStyle
        {
            get
            {

                if (_labelMiddleRightStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleRight;
                    style.fontSize = 16;

                    _labelMiddleRightStyle = style;
                }
                return _labelMiddleRightStyle;
            }
        }


        private static GUIStyle _labelMiddleRightStyleGray10;
        public static GUIStyle labelMiddleRightStyleGray10
        {
            get
            {

                if (_labelMiddleRightStyleGray10 == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleRight;
                    style.fontSize = 10;
                    style.normal.textColor = Color.gray;

                    _labelMiddleRightStyleGray10 = style;
                }
                return _labelMiddleRightStyleGray10;
            }
        }

        private static GUIStyle _labelRichStyle;
        public static GUIStyle labelRichStyle
        {
            get
            {

                if (_labelRichStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.richText = true;
                    _labelRichStyle = style;
                }
                return _labelRichStyle;
            }
        }

        private static GUIStyle _labelRichBarStyle;
        public static GUIStyle labelRichBarStyle
        {
            get
            {

                if (_labelRichBarStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
                    style.richText = true;
                    style.alignment = TextAnchor.MiddleLeft;
                    _labelRichBarStyle = style;
                }
                return _labelRichBarStyle;
            }
        }


        private static GUIStyle _labelMatrixHeadUpStyle;
        public static GUIStyle labelMatrixHeadUpStyle
        {
            get
            {

                if (_labelMatrixHeadUpStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.LowerCenter;
                    style.wordWrap = true;
                    style.richText = true;

                    style.fontSize = 12;

                    _labelMatrixHeadUpStyle = style;
                }
                return _labelMatrixHeadUpStyle;
            }
        }


        private static GUIStyle _labelMatrixHeadLeftStyle;
        public static GUIStyle labelMatrixHeadLeftStyle
        {
            get
            {

                if (_labelMatrixHeadLeftStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleRight;
                    style.fontSize = 12;
                    style.richText = true;

                    _labelMatrixHeadLeftStyle = style;
                }
                return _labelMatrixHeadLeftStyle;
            }
        }

        private static GUIStyle _labelTableHeadStyle;
        public static GUIStyle labelTableHeadStyle
        {
            get
            {

                if (_labelTableHeadStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleCenter;
                    style.fontSize = 16;
                    style.fontStyle = FontStyle.Bold;

                    _labelTableHeadStyle = style;
                }
                return _labelTableHeadStyle;
            }
        }


        private static GUIStyle _buttonLabelLeftStyle;
        public static GUIStyle buttonLabelLeftStyle
        {
            get
            {

                if (_buttonLabelLeftStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.miniButtonLeft);
                    style.alignment = TextAnchor.MiddleLeft;

                    _buttonLabelLeftStyle = style;
                }
                return _buttonLabelLeftStyle;
            }
        }


        private static GUIStyle _labelSceneStyle;
        public static GUIStyle labelSceneStyle
        {
            get
            {

                if (_labelSceneStyle == null)
                {
                    GUIStyle style = new GUIStyle(EditorStyles.label);
                    style.alignment = TextAnchor.MiddleCenter;
                    style.fontSize = 16;
                    style.fontStyle = FontStyle.Bold;

                    _labelSceneStyle = style;
                }
                return _labelSceneStyle;
            }
        }


    }
}
