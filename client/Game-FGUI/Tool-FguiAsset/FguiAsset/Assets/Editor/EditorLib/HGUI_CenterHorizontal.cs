using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 10:18:07 AM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    /** 水平居中 */
    public partial class HGUI
    {
        /** 水平居中 -- 开始 */
        public static void BeginCenterHorizontal()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Box("", GUIStyle.none, GUILayout.ExpandWidth(true));
        }

        /** 水平居中 -- 结束 */
        public static void EndCenterHorizontal()
        {

            GUILayout.Box("", GUIStyle.none, GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();
        }

    }
}
