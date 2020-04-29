#if UNITY_EDITOR
using System;

public static class User32Dll
{
    [System.Runtime.InteropServices.DllImport("USER32.DLL")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
}
#endif