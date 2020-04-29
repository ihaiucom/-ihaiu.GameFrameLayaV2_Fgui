using System;
using System.IO;


namespace EditorFguiAssets
{
    public class CmdType
    {
        // 生成代码
        public const string generatecode = "generatecode";
        // 修改 xlsx
        public const string modifyxml = "modifyxml";
    }

    public class Setting
    {
        public static Options Options = new Options();
    }
}