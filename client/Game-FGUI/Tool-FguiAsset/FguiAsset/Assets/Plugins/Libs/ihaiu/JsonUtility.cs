using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class HJsonUtility
{
	public static string ToJson(object obj, bool isFormat = true)
	{
		return JsonConvert.SerializeObject (obj, isFormat ? Formatting.Indented : Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
	}

	public static T FromJson<T>(string json)
	{
		return JsonConvert.DeserializeObject<T> (json);
	}


    public static string ToJsonType(object obj, bool isFormat = true)
    {
        return JsonConvert.SerializeObject(obj, isFormat ? Formatting.Indented : Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
            //TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full
        });
    }

    public static T FromJsonType<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings() {
            TypeNameHandling = TypeNameHandling.All
        });
    }

}


//public class LimitPropsContractResolver : DefaultContractResolver
//{
//    string[] props = null;

//    bool retain;

//    /// <summary>
//    /// 构造函数
//    /// </summary>
//    /// <param name="props">传入的属性数组</param>
//    /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
//    public LimitPropsContractResolver(string[] props, bool retain = true)
//    {
//        //指定要序列化属性的清单
//        this.props = props;

//        this.retain = retain;
//    }

//    protected override IList<JsonProperty> CreateProperties(Type type,

//    MemberSerialization memberSerialization)
//    {
//        IList<JsonProperty> list =
//        base.CreateProperties(type, memberSerialization);
//        //只保留清单有列出的属性
//        return list.Where(p =>
//        {
//            if (retain)
//            {
//                return props.Contains(p.PropertyName);
//            }
//            else
//            {
//                return !props.Contains(p.PropertyName);
//            }
//        }).ToList();
//    }
//}