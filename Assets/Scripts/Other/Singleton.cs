using UnityEngine;

namespace Metalink.Utility
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Destroy ���� Ȯ�ο�
        private static bool g_ShuttingDown = false;
        private static object g_Lock = new object();
        private static T g_Instance;

        public static T Instance
        {
            get
            {
                // ���� ���� �� Object ���� �̱����� OnDestroy �� ���� ���� �� ���� �ִ�. 
                // �ش� �̱����� gameObject.Ondestory() ������ ������� �ʰų� ����Ѵٸ� null üũ�� ������
                if (g_ShuttingDown)
                {
                    Debug.Log("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                    return null;
                }

                lock (g_Lock)    //Thread Safe
                {
                    if (g_Instance == null)
                    {
                        g_Instance = (T)FindObjectOfType(typeof(T));

                        if (g_Instance == null)
                        {
                            var singletonObject = new GameObject();
                            g_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return g_Instance;
                }
            }
        }

        protected virtual void OnApplicationQuit()
        {
            g_ShuttingDown = true;
        }

        protected virtual void OnDestroy()
        {
            g_ShuttingDown = true;
        }
    }
}