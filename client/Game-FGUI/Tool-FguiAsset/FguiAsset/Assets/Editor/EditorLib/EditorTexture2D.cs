using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEditor;

public class EditorTexture2D
{
    public static Texture2D Load(string path, int width = 100, int height = 100)
    {
        if(!File.Exists(path))
        {
            return null;
        }

        //创建文件读取流
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        return texture;
    }

    public static bool Draw(Texture2D texture, int width = 100, int height = 100)
    {
        GUIContent content = texture == null ? new GUIContent("没有缩列图") : new GUIContent(texture);
        return GUILayout.Button(content, GUILayout.Width(width), GUILayout.Height(height));
    }
}