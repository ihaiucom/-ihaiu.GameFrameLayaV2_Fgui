// ======================================
// auth: 曾峰
// email:zengfeng75@qq.com
// qq:593705098
// http://blog.ihaiu.com
// --------------------------------------

using UnityEngine;
using System.Collections;
using System;

public static class bit 
{
	public static int band(int val,  int b)
	{
		return val & b;
	}

	public static int bor(int val,  int b)
	{
		return val | b;
	}


	public static int bnot(int val)
	{
		return ~val;
	}

	public static int bxor(int val, int b)
	{
		return val ^ b;
	}


	public static int lshift(int val, int b)
	{
		return val << b;
	}


	public static int rshift(int val, int b)
	{
		return val >> b;
	}


	public static string to0x(int val)
	{
		return "0x" + Convert.ToString (val, 16);
	}

}
