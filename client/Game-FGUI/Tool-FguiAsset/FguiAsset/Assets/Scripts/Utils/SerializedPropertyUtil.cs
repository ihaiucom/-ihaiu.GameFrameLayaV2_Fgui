#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public static class SerializedPropertyUtil 
{
	[MenuItem("Edit/Game/PrintTagManager")]
	public static void PrintTagManager () 
	{
		SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
		SerializedProperty it = tagManager.GetIterator();
        StringWriter sw = new StringWriter();
        while (it.NextVisible(true))
        {
			ToStr(it, false, sw);
        }

        Debug.Log(sw.ToString());
	}

	public static void Print(this SerializedProperty p, bool enterChild = true)
	{
		Debug.Log(ToStr(p, enterChild).ToString());
	}

	public static StringWriter ToStr(this SerializedProperty p,  bool enterChild = true, StringWriter sw = null, string pre="")
	{
		if (sw == null)
		{
			sw = new StringWriter();
		}

		if(p.propertyType == SerializedPropertyType.Generic)
		{
			sw.WriteLine(string.Format(pre + "name={0}, displayName={1}, isAnimated={2}, isArray={3}, isExpanded={4}, isInstantiatedPrefab={5}, propertyType={6}, propertyPath={7}, depth={8}, type={9}, arraySize={10}", p.name, p.displayName, p.isAnimated, p.isArray, p.isExpanded, p.isInstantiatedPrefab, p.propertyType, p.propertyPath, p.depth, p.type, (p.isArray ? p.arraySize + "" : "NoSize") ));

		}
		else if (p.isArray && p.propertyType == SerializedPropertyType.ArraySize)
		{
			sw.WriteLine(string.Format(pre + "name={0}, displayName={1}, isAnimated={2}, isArray={3}, isExpanded={4}, isInstantiatedPrefab={5}, propertyType={6}, propertyPath={7}, depth={8}, type={9}, arraySize={10}", p.name, p.displayName, p.isAnimated, p.isArray, p.isExpanded, p.isInstantiatedPrefab, p.propertyType, p.propertyPath, p.depth, p.type, p.arraySize));

		}
		else
		{
			//            sw.WriteLine(string.Format(pre + "name={0}, displayName={1}, isAnimated={2}, isArray={3}, isExpanded={4}, isInstantiatedPrefab={5}, propertyType={6}, propertyPath={7}, depth={8}, type={9}, val={10}", p.name, p.displayName, p.isAnimated, p.isArray, p.isExpanded, p.isInstantiatedPrefab, p.propertyType, p.propertyPath, p.depth, p.type, GetVal(p)));
			sw.WriteLine(string.Format(pre + "name={0}, displayName={1}, isArray={2},  propertyType={3}, propertyPath={4}, depth={5}, type={6}, val={7}", p.name, p.displayName, p.isArray, p.propertyType, p.propertyPath, p.depth, p.type, GetVal(p)));

		}

		if(enterChild)
		{
			if(p.isArray && p.propertyType != SerializedPropertyType.String)
			{
				sw.WriteLine("");
				for(int i = 0; i < p.arraySize; i ++)
				{
					SerializedProperty child = p.GetArrayElementAtIndex(i);
					ToStr(child, enterChild, sw, pre + "--");
				}
				sw.WriteLine("");
			}
			else if(p.propertyType == SerializedPropertyType.Generic)
			{
				string propertyPath = p.propertyPath;
				while (p.NextVisible(true))
				{
					if(p.propertyPath.StartsWith(propertyPath))
					{
						ToStr(p, enterChild, sw, pre + "--");
					}
					else
					{
						break;
					}
				}
			}
		}





		return sw;
	}

	public static object GetVal(SerializedProperty p)
	{
		switch (p.propertyType)
		{
		case SerializedPropertyType.Integer:
			return p.intValue;
		case SerializedPropertyType.Boolean:
			return p.boolValue;
		case SerializedPropertyType.Float:
			return p.floatValue;
		case SerializedPropertyType.String:
			return p.stringValue;
		case SerializedPropertyType.Color:
			return p.colorValue;
		case SerializedPropertyType.ObjectReference:
			return p.objectReferenceValue;
		case SerializedPropertyType.LayerMask:
			return p.intValue;
		case SerializedPropertyType.Enum:
			return p.enumNames;
		case SerializedPropertyType.Vector2:
			return p.vector2Value;
		case SerializedPropertyType.Vector3:
			return p.vector3Value;
		case SerializedPropertyType.Vector4:
			return p.vector4Value;
		case SerializedPropertyType.Rect:
			return p.rectValue;
		case SerializedPropertyType.Character:
			return p.stringValue;
		case SerializedPropertyType.AnimationCurve:
			return p.animationCurveValue;
		case SerializedPropertyType.Bounds:
			return p.boundsValue;
		case SerializedPropertyType.Gradient:
			return p.animationCurveValue;
		case SerializedPropertyType.Quaternion:
			return p.quaternionValue;
		}

		return "Dont know";
	}
}
#endif