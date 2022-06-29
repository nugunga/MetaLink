using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;

namespace Metalink.Utility
{
    public static class PythonLoader
    {
        private static string Folder => Application.dataPath + "/Scripts/Python/";

        /// <summary>
        /// ���̽� ���� ����
        /// </summary>
        /// <param name="fileName">������ �̸� (Ȯ���� ����)</param>
        public static void RunFile(string fileName)
        {
            PythonRunner.RunFile(Folder + fileName + ".py");
        }
    }
}
