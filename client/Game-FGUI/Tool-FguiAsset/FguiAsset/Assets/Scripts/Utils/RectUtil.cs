using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/28/2017 7:42:42 PM
*  @Description:    
* ==============================================================================
*/
public static class RectUtil
{
    public static Rect Set(this Rect src, Rect val)
    {
        src.x = val.x;
        src.y = val.y;
        src.width   = val.width;
        src.height  = val.height;
        return src;
    }
}