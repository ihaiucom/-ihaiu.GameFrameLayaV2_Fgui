using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/23/2017 6:27:54 PM
*  @Description:    
* ==============================================================================
*/

public static class GizmosUtils
{
    public static void DrawCircle(Vector3 position, float radius)
    {
        //Gizmos
        int smoothAngle = 10;
        int count = 360 / smoothAngle;

        Vector3 prePoint = HMath.PointAngle(position, 0, radius);
        Vector3 point;
        for (int i = 1; i < count - 1; i ++)
        {
            int angle = smoothAngle * i;
            point = HMath.PointAngle(position, angle, radius);
            Gizmos.DrawLine(prePoint, point);
            prePoint = point;
        }

        point = HMath.PointAngle(position, 360, radius);
        Gizmos.DrawLine(prePoint, point);


    }
}
