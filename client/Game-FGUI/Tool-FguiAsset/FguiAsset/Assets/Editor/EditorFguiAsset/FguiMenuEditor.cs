using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;


namespace EditorFguiAssets
{
    public class GameMenuEditor
	{
		[MenuItem("Fgui资源/测试设置")]
		public static void TestSetting()
		{
        }


        [MenuItem("Fgui资源/查找相同文件")]
        public static void OpenFindSimpleFile()
        {
            FguiSimpleFileEditorWindow.Open();
        }


        [MenuItem("Fgui资源/清理没用到的文件")]
        public static void OpenClearNoUse()
        {
            FguiClearNoUseEditorWindow.Open();
        }

        [MenuItem("Fgui资源/清理空文件夹")]
        public static void OpenClearEmpyFolder()
        {
            FguiFindEmpyFolderEditorWindow.Open();
        }



    }

}