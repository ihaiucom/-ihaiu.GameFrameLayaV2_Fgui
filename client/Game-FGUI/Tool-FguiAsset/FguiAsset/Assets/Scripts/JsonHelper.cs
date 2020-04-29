using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class JsonHelper
{
    public static string ConvertJsonString(this string json)
    {
        //格式化json字符串
        //JsonSerializer serializer = new JsonSerializer();
        //TextReader tr = new StringReader(json);
        //JsonTextReader jtr = new JsonTextReader(tr);
        //object obj = serializer.Deserialize(jtr);
        object obj = JsonConvert.DeserializeObject<object>(json);
        if (obj != null)
        {
            //StringWriter textWriter = new StringWriter();
            //JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
            //{
            //    Formatting = Formatting.Indented,
            //    Indentation = 4,
            //    IndentChar = ' '
            //};
            //serializer.Serialize(jsonWriter, obj);
            //return textWriter.ToString();
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        else
        {
            return json;
        }
    }


    public static T FromJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }


    public static string ToJsonType(object obj, bool isFormat = true)
    {
        return JsonConvert.SerializeObject(obj, isFormat ? Formatting.Indented : Formatting.None);
    }
}