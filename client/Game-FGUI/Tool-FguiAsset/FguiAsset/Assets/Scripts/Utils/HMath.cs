using UnityEngine;
using System.Collections;




public class HMath {

    /** 获取点相对原点的角度 */
	public static float AngleBetweenForward2Vector(Vector3 vectorAim)
	{
		vectorAim.y = 0;
		float angleBetweenForward2Vector = 0;
		if (vectorAim.x>0)
		{
			angleBetweenForward2Vector = Vector3.Angle(Vector3.forward, vectorAim);
		}
		else
		{
			angleBetweenForward2Vector = 360 - Vector3.Angle(Vector3.forward, vectorAim);
		}
		return angleBetweenForward2Vector;
	}


    /** 获取两个点的角度 */
    public static float AngleBetweenVector(Vector3 from, Vector3 to)
	{
		Vector3 vectorAim = to - from;
		vectorAim.y = 0;
		float angleBetweenForward2Vector = 0;
		if (vectorAim.x>0)
		{
			angleBetweenForward2Vector = Vector3.Angle(Vector3.forward, vectorAim);
		}
		else
		{
			angleBetweenForward2Vector = 360 - Vector3.Angle(Vector3.forward, vectorAim);
		}
		return angleBetweenForward2Vector;
	}

	public static float radian(float fromX, float fromY, float toX, float toY)
	{
		float dx = toX - fromX;
		float dy = toY - fromY;
		return Mathf.Atan2(dy, dx);
	}
		
	public static float angle(float fromX, float fromY, float toX, float toY)
	{
		return radian(fromX, fromY, toX, toY) * 180f / Mathf.PI ;
	}
		
	public static float angleToRadian(float angle)
	{
		return angle * Mathf.PI / 180f;
	}
		
		
	public static float radianToAngle(float radian)
	{
		return radian * 180f / Mathf.PI;
	}
		
	public static float distance(float fromX, float fromY, float toX, float toY)
	{
		float dx = toX - fromX;
		float dy = toY - fromY;
		return Mathf.Sqrt(dx * dx + dy * dy);
	}
		
	public static float distanceForYKey(float fromX, float fromY, float toX, float toY ,float cy = 1) 
	{
		float dx = toX - fromX;
		float dy = toY - fromY;
		dy *= cy;
		return Mathf.Sqrt(dx * dx + dy * dy);
	}
		
	public static Vector2 directionPoint(float fromX, float fromY , float toX , float toY, float length) 
	{
		float angle = radian(fromX, fromY, toX, toY);
		Vector2 point = new Vector2();
			
		point.x = Mathf.Cos(angle) * length;
		point.y = Mathf.Sin(angle) * length;
		point.x += fromX;
		point.y += fromY;
		return point;
	}


		
	public static float directionPointX(float fromX, float fromY, float toX, float toY, float length)
	{
		return Mathf.Cos(radian(fromX, fromY, toX, toY)) * length + fromX ;
	}
		
	public static float directionPointY(float fromX, float fromY, float toX, float toY, float length)
	{
		return Mathf.Sin(radian(fromX, fromY, toX, toY)) * length + fromY ;
	}
		
	public static float radianPointX(float radian, float length, float fromX)
	{
		return Mathf.Cos(radian) * length + fromX ;
	}
		
	public static float radianPointY(float radian, float length, float fromY)
	{
		return Mathf.Sin(radian) * length + fromY ;
	}


    /** 获取from点到to点方向距离from点distance的点 */
    public static Vector3 Point(Vector3 from, Vector3 to, float distance)
    {
        Vector3 direction = to - from;
        return from + direction.normalized * distance;
    }


    /** 获取点到某个角度方向距离的点 */
    public static Vector3 PointAngle(Vector3 o, float angle, float length)
	{
		return PointRadian(o, Mathf.Deg2Rad * angle, length);
	}

    /** 获取点到某个弧度方向距离的点 */
	public static Vector3 PointRadian(Vector3 o, float radian, float length)
	{
		Vector3 p = o.Clone();
		p.x = o.x + Mathf.Sin(radian) * length;
		p.z = o.z + Mathf.Cos(radian) * length;
		return p;
	}

		
	/** 点到直线的距离 */
	public static float distance(Vector3 point, Vector3 line)
	{
			
		Vector3 ab = line;
		Vector3 ac = point;
			
			
		Vector3 cross = Vector3.Cross(ac, ab);
		float wd = cross.magnitude / ab.magnitude;
			
		return wd;
	}

	/** 点到直线的距离 */
	public static float distance(Vector3 point, Vector3 lineFrom, Vector3 lineTo)
	{

		Vector3 ab = lineTo - lineFrom;
		Vector3 ac = point - lineFrom;
			

		Vector3 cross = Vector3.Cross(ac, ab);
		float wd = cross.magnitude / ab.magnitude;
			
		return wd;
	}


	/** 直线与圆相交。圆半径和直线的相交点 */
	public static Vector3 IntersectionPoint(Vector3 point, Vector3 hit, float radius, Vector3 lineFrom, Vector3 lineTo)
	{
		float c = radius;
		float a = HMath.distance(point, lineFrom, lineTo);
		float b = Mathf.Sqrt( c * c - a * a);
		return hit + (lineTo - lineFrom).normalized * b;
	}

		
	/** 点到直线的垂直线和直线的相交点 */
	public static Vector3 IntersectionPoint(Vector3 point, Vector3 lineFrom, Vector3 lineTo)
	{
		Vector3 line = (lineTo - lineFrom).normalized;
		return Vector3.Dot((point - lineFrom), line) * line + lineFrom;
	}
}