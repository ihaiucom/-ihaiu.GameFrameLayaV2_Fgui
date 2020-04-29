using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/22/2017 8:45:18 PM
*  @Description:    
* ==============================================================================
*/

public static class TransformUtils
{
    public static void ClearChilds(this Transform root)
    {
        int count = root.childCount;
        for (int i = count - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(root.GetChild(i));
        }
    }


    public static Transform[] ChildsToArray(this Transform root)
    {
        int count = root.childCount;
        Transform[] list = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            list[i] = root.GetChild(i);
        }
        return list;
    }

    public static List<Transform> ChildsToList(this Transform root)
    {
        List<Transform> list = new List<Transform>();
        int count = root.childCount;
        for(int i = 0; i < count; i ++)
        {
            list.Add(root.GetChild(i));
        }
        return list;
    }

    public static List<Transform> SortByName(this Transform root)
    {
        List<Transform> list = root.ChildsToList();
        list.Sort(TransformCompare);
        int count = list.Count;
        for(int i = 0; i < count; i ++)
        {
            list[0].SetAsLastSibling();
        }
        return list;
    }

    private static int TransformCompare(Transform a, Transform b)
    {
        return a.name.CompareTo(b.name);
    }

	public static void SetActive(this Transform tf, bool isShow)
	{
		if(tf != null)
		{
			tf.gameObject.SetActive(isShow);
		}
	}

	public static void SetLocalPositionX(this Transform tf, float x)
	{
		if (tf != null)
		{
			tf.localPosition = new Vector3(x, tf.localPosition.y, tf.localPosition.z);
		}
	}

	public static void SetLocalPositionY(this Transform tf, float y)
	{
		if (tf != null)
		{
			tf.localPosition = new Vector3(tf.localPosition.x, y, tf.localPosition.z);
		}
	}

	public static void SetLocalPositionZ(this Transform tf, float z)
	{
		if (tf != null)
		{
			tf.localPosition = new Vector3(tf.localPosition.x, tf.localPosition.y, z);
		}
	}

	public static void SetPositionX(this Transform tf, float x)
	{
		if (tf != null)
		{
			tf.position = new Vector3(x, tf.position.y, tf.position.z);
		}
	}

	public static void SetPositionY(this Transform tf, float y)
	{
		if (tf != null)
		{
			tf.position = new Vector3(tf.position.x, y, tf.position.z);
		}
	}

	public static void SetPositionZ(this Transform tf, float z)
	{
		if (tf != null)
		{
			tf.position = new Vector3(tf.position.x, tf.position.y, z);
		}
	}

    public static void SetAnchoredPositionX(this RectTransform tf, float x)
    {
        if (tf != null)
        {
            tf.anchoredPosition = new Vector2(x, tf.anchoredPosition.y);
        }
    }

    public static void SetAnchoredPositionY(this RectTransform tf, float y)
    {
        if (tf != null)
        {
            tf.anchoredPosition = new Vector2(tf.anchoredPosition.x, y);
        }
    }


}
