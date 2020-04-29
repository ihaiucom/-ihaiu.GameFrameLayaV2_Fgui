using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class Http
{
    /// Get请求 
    public static string GetHttpResponse(string url, int Timeout = 3000)
    {
        Loger.Log(url);

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd(); myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        catch(Exception e)
        {
            Loger.Log(url + " " + e.ToString());
        }
        return string.Empty;
    }



    /// 创建POST方式的HTTP请求  
    public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
    {
        HttpWebRequest request = null;
        //如果是发送HTTPS请求  
        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
        {
            request = WebRequest.Create(url) as HttpWebRequest;
        }
        else
        {
            request = WebRequest.Create(url) as HttpWebRequest;
        }
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        //设置代理UserAgent和超时
        //request.UserAgent = userAgent;
        //request.Timeout = timeout; 

        if (cookies != null)
        {
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookies);
        }
        //发送POST数据  
        if (!(parameters == null || parameters.Count == 0))
        {
            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    i++;
                }
            }
            byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        string[] values = request.Headers.GetValues("Content-Type");
        return request.GetResponse() as HttpWebResponse;
    }


    /// <summary>
    /// 获取请求的数据
    /// </summary>
    public static string GetResponseString(HttpWebResponse webresponse)
    {
        using (Stream s = webresponse.GetResponseStream())
        {
            StreamReader reader = new StreamReader(s, Encoding.UTF8);
            return reader.ReadToEnd();

        }
    }
}

