using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/23/2017 1:34:29 PM
*  @Description:    
* ==============================================================================
*/

public static class PathGizmos
{

    public static Transform[] DrawPath(Transform[] list, Color color, float nodeSize = 1f)
    {
        if (list == null || list.Length == 0)
            return list;

        Gizmos.color = color;
        int nodeCount = list.Length;

        Vector3 prevPt = list[0].position;
        Gizmos.DrawWireSphere(prevPt, nodeSize);
        for (int i = 1; i < nodeCount; i++)
        {
            Vector3 currPt = list[i].position;
            Gizmos.DrawLine(currPt, prevPt);
            Gizmos.DrawWireSphere(currPt, nodeSize);
            prevPt = currPt;
        }

        return list;
    }


    public static List<Vector3> DrawPath(List<Vector3> list, Color color, float nodeSize = 1f)
    {
        if (list == null || list.Count == 0)
            return list;

        Gizmos.color = color;
        int nodeCount = list.Count;

        Vector3 prevPt = list[0];
        Gizmos.DrawWireSphere(prevPt, nodeSize);
        for (int i = 1; i < nodeCount; i++)
        {
            Vector3 currPt = list[i];
            Gizmos.DrawLine(currPt, prevPt);
            Gizmos.DrawWireSphere(currPt, nodeSize);
            prevPt = currPt;
        }

        return list;
    }
}
