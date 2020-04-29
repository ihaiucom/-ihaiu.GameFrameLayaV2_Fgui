using UnityEngine;
using System.Collections;


public static class VectorUtil {

    /** 角度转成Rotation */
    public static Vector3 ToAngleVInt3(this float src)
    {
        return new Vector3(0, src, 0);
    }

    //public static Vector3 ToVInt3(this Vector3 src)
    //{
    //    return new Vector3(src);
    //}

    public static string ToStr(this Vector3[] list)
	{
		string str = "";
		string gap = "";
		for(int i = 0; i < list.Length; i ++)
		{
			Vector3 v = list[i];
			str += gap + i + "\t" + v;
			gap = "\n";
		}
		return str;
	}

	public static void Print(this Vector3[] list)
	{
		for(int i = 0; i < list.Length; i ++)
		{
			Debug.Log(i + "\t" + list[i]);
		}
	}


    public static Quaternion ToQuaternion(this Vector3 src)
    {
        return Quaternion.Euler(src);
    }

    public static Vector2 ToV2(this Vector3 src)
	{
		return new Vector2(src.x, src.z);
	}

	public static Vector3 ToV3(this Vector2 src)
	{
		return new Vector3(src.x, 0f, src.y);
	}

		
	public static Vector3 ZToY(this Vector3 src)
	{
		return new Vector3(src.x, src.z, 0);
	}

    public static bool EqualsXZ(this Vector3 a, Vector3 b)
    {
        return Mathf.Abs(a.x - b.x) < 0.01f && Mathf.Abs(a.z - b.z) < 0.01f;
    }

		
	public static float SqrDistance( this Vector3 vec1 , Vector3 vec2 )
	{
		return (vec1 - vec2).sqrMagnitude ;
	}

	public static Vector3 Multiply(this Vector3 a, Vector3 b)
	{
		return new Vector3(a.x * b.x,		a.y * b.y,		a.z * b.z);
	}

		
	public static Vector3 Clone(this Vector3 src)
	{
		return new Vector3(src.x, src.y, src.z);
	}

		
	public static Vector3 SetX(this Vector3 src, float x)
	{
		src.x = x;
		return src;
	}

		
	public static Vector3 SetY(this Vector3 src, float y)
	{
		src.y = y;
		return src;
	}
		
	public static Vector3 SetZ(this Vector3 src, float z)
	{
		src.z = z;
		return src;
	}

    public static Vector3 Set( this Vector3 src, Vector3 val)
    {
        src.x = val.x;
        src.y = val.y;
        src.z = val.z;
        return src;
    }

    //-----------------------------------------------
    public static Vector2 Clone(this Vector2 src)
	{
		return new Vector2(src.x, src.y);
	}


	public static Vector2 SetX(this Vector2 src, float x)
	{
		src.x = x;
		return src;
	}
		
		
	public static Vector2 SetY(this Vector2 src, float y)
	{
		src.y = y;
		return src;
	}

    public static Vector2 Set(this Vector2 src, Vector2 val)
    {
        src.x = val.x;
        src.y = val.y;
        return src;
    }


    public static float EulerAngles360(this float src)
    {
        if (src >= 360)
        {
            src -= 360;
        }
        else if(src < 0)
        {
            src += 360;
        }
        return src;
    }

    public static Vector3 EulerAngles360(this Vector3 src)
    {
        src.x = EulerAngles360(src.x);
        src.y = EulerAngles360(src.y);
        src.z = EulerAngles360(src.z);
        return src;
    }


}
