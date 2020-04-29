using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 6:12:54 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public static class ColorUtil
    {
        public static string ToStrRGB(this Color32 src)
        {
            return Convert.ToString(src.r , 16).FillLeft(2)
                        + Convert.ToString(src.g , 16).FillLeft(2)
                        + Convert.ToString(src.b , 16).FillLeft(2);
        }


        public static string ToStrRGBA(this Color32 src)
        {

            return Convert.ToString(src.r, 16).FillLeft(2)
                        + Convert.ToString(src.g, 16).FillLeft(2)
                        + Convert.ToString(src.b, 16).FillLeft(2)
                        + Convert.ToString(src.a, 16).FillLeft(2);
        }

        public static string ToStr(this Color src)
        {
            return "#" + ToStrRGB(src);
        }


        public static string ToStr0x(this Color src)
        {
            return "0x" + ToStrRGB(src);
        }


        //--------------------------
        public static string ToStr32(this Color src)
        {
            return "#" + ToStrRGBA(src);
        }


        public static string ToStr320x(this Color src)
        {
            return "0x" + ToStrRGBA(src);
        }

        //=============================
        

        public static string ToStr(this Color32 src)
        {
            return "#" + ToStrRGB(src);
        }


        public static string ToStr0x(this Color32 src)
        {
            return "0x" + ToStrRGB(src);
        }

        //--------------------------
        public static string ToStr32(this Color32 src)
        {
            return "#" + ToStrRGBA(src);
        }


        public static string ToStr320x(this Color32 src)
        {
            return "0x" + ToStrRGBA(src);
        }

        //--------------------------
        public static Color Clone(this Color src)
        {
            return new Color(src.r, src.g, src.b, src.a);
        }


        public static Color SetAlhpa(this Color src, float a)
        {
            src.a = a;
            return src;
        }


		public static Color HexToColor(string hex)
		{
			byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
			float r = br / 255f;
			float g = bg / 255f;
			float b = bb / 255f;
			float a = cc / 255f;
			return new Color(r, g, b, a);
		}

		public static Color32 HexToColor32(string hex)
		{
			byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r, g, b, a);
		}
			
    }
}
