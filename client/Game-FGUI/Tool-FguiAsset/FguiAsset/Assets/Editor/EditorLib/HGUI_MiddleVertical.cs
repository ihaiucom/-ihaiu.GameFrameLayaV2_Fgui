using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 10:20:34 AM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    /** 垂直居中 */
    public partial class HGUI
    {
        /** 垂直居中 -- 开始 */
        public static void BeginMiddleVertical(float height)
        {
            GUILayout.BeginVertical(GUILayout.Height(height));

            GUILayout.Box("", GUIStyle.none, GUILayout.ExpandHeight(true));
        }

        /** 垂直居中 -- 结束 */
        public static void EndMiddleVertical()
        {

            GUILayout.Box("", GUIStyle.none, GUILayout.ExpandHeight(true));
            GUILayout.EndVertical();
        }
    }
}
