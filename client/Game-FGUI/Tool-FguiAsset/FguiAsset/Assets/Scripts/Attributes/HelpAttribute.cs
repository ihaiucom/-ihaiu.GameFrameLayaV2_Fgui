using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.ComponentModel;

[AttributeUsage(AttributeTargets.All, AllowMultiple=true, Inherited=true)]
public class HelpAttribute : Attribute
{
	public readonly string toolTip = "";
	public readonly string description = "";

	public HelpAttribute(string description, string toolTip)
	{
		this.description = description;
		this.toolTip = toolTip;
	}

	
	public HelpAttribute(string description)
	{
		this.description = description;
	}
}


public static class HelpUtils
{

    public static string GetHelpDescription(Type type, string filedname)
    {
        FieldInfo field = type.GetField(filedname);
        object[] objs = field.GetCustomAttributes(typeof(HelpAttribute), false);    //获取描述属性
        if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
            return filedname;
        HelpAttribute descriptionAttribute = (HelpAttribute)objs[0];
        return descriptionAttribute.description;
    }


    public static string GetHelpDescription(this Enum enumValue)
    {
        string value = enumValue.ToString();
        FieldInfo field = enumValue.GetType().GetField(value);
        object[] objs = field.GetCustomAttributes(typeof(HelpAttribute), false);    //获取描述属性
        if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
            return value;
        HelpAttribute descriptionAttribute = (HelpAttribute)objs[0];
        return descriptionAttribute.description;
    }


    public static string GetDescription(this Enum enumValue)
    {
        string value = enumValue.ToString();
        FieldInfo field = enumValue.GetType().GetField(value);
        object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
        if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
            return value;
        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
        return descriptionAttribute.Description;
    }
}

