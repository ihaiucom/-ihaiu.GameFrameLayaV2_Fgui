using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 1:51:08 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{

    /** 样式 -- box */
    public partial class HStyle
    {

        /** 描边的方框样式 */
        public static GUIStyle Box(RectOffset margin, RectOffset padding)
        {
            GUIStyle style = new GUIStyle(helpBox);
            style.margin    = margin;
            style.padding   = padding;
            return style;
        }


        private static GUIStyle _boxModuleStyle;
        public static GUIStyle boxModuleStyle
        {
            get
            {
                if (_boxModuleStyle == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.padding = new RectOffset(15, 15, 15, 15);
                    style.margin = new RectOffset(20, 20, 5, 5);

                    _boxModuleStyle = style;
                }
                return _boxModuleStyle;
            }
        }



        private static GUIStyle _boxMarginLeftStyle;
        public static GUIStyle boxMarginLeftStyle
        {
            get
            {
                if (_boxMarginLeftStyle == null)
                {

                    GUIStyle style = new GUIStyle(helpBox);
                    style.margin = new RectOffset();
                    style.margin.left = 30;
                    style.padding = new RectOffset(10, 10, 10, 10);
                    _boxMarginLeftStyle = style;
                }
                return _boxMarginLeftStyle;
            }
        }


        private static GUIStyle _boxBarStyle;
        public static GUIStyle boxBarStyle
        {
            get
            {
                if (_boxBarStyle == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.padding = new RectOffset(5, 5, 5, 5);
                    style.margin = new RectOffset(5, 5, 10, 10);

                    _boxBarStyle = style;
                }
                return _boxBarStyle;
            }
        }

        private static GUIStyle _boxMiddleCenterStyle;
        public static GUIStyle boxMiddleCenterStyle
        {
            get
            {
                if (_boxMiddleCenterStyle == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.margin = new RectOffset();
                    style.alignment = TextAnchor.MiddleCenter;
                    _boxMiddleCenterStyle = style;
                }
                return _boxMiddleCenterStyle;
            }
        }

        private static GUIStyle _boxColumnStyle;
        public static GUIStyle boxColumnStyle
        {
            get
            {
                if (_boxColumnStyle == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.margin = new RectOffset();
                    style.padding = new RectOffset(10, 10, 10, 10);
                    _boxColumnStyle = style;
                }
                return _boxColumnStyle;
            }
        }

        private static GUIStyle _boxTableHeadStyle;
        public static GUIStyle boxTableHeadStyle
        {
            get
            {
                if (_boxTableHeadStyle == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.alignment = TextAnchor.MiddleCenter;
                    style.padding = new RectOffset(5, 5, 5, 5);
                    style.margin = new RectOffset(5, 5, 10, 10);

                    _boxTableHeadStyle = style;
                }
                return _boxTableHeadStyle;
            }
        }


        private static GUIStyle _boxTableHeadStyle2;
        public static GUIStyle boxTableHeadStyle2
        {
            get
            {
                if (_boxTableHeadStyle2 == null)
                {
                    GUIStyle style = new GUIStyle(helpBox);
                    style.alignment = TextAnchor.MiddleCenter;

                    _boxTableHeadStyle2 = style;
                }
                return _boxTableHeadStyle2;
            }
        }





    }
}
