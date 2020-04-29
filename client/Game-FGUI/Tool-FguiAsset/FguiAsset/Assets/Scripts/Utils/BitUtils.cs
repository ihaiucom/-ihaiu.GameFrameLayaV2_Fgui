// ======================================
// auth: 曾峰
// email:zengfeng75@qq.com
// qq:593705098
// http://blog.ihaiu.com
// --------------------------------------
using System;

public static class BitUtils
{
    public static uint BitUnset(uint ui, int len , int bit){
        uint mask = (uint)((1<<len+1)-1);
        return ui & ~(mask<<bit) ;
    }

    public static uint BitSet(uint ui, int len, int bit, uint val){
        uint mask = (uint)((1<<len+1)-1);
        uint nv = mask & val;
        return ui & ~(mask<<bit) | (nv<<bit);
    }

    public static uint BitGet(uint ui, int len, int bit){
        uint mask = (uint)((1<<len+1)-1);
        return ui & (mask << bit);
    }

    public static ulong BitUnset(ulong ui, int len , int bit){
        ulong mask = (ulong)((1<<len+1)-1);
        return ui & ~(mask<<bit) ;
    }
    
    public static ulong BitSet(ulong ui, int len, int bit, ulong val){
        ulong mask = (ulong)((1<<len+1)-1);
        ulong nv = mask & val;
        return ui & ~(mask<<bit) | (nv<<bit);
    }
    
    public static ulong BitGet(ulong ui, int len, int bit){
        ulong mask = (ulong)((1<<len+1)-1);
        return ui & (mask << bit);
    }
}

