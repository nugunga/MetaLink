using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;

namespace Metalink.Utility
{
    public static class PythonLoader
    {
        private static string Folder => Application.dataPath + "/Scripts/Python/";

        /// <summary>
        /// 파이썬 파일 실행
        /// </summary>
        /// <param name="fileName">파일의 이름 (확장자 없음)</param>
        public static void RunFile(string fileName)
        {
            PythonRunner.RunFile(Folder + fileName + ".py");
        }
    }
}
