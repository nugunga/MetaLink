using UnityEngine.SceneManagement;
using UnityEngine;

namespace Metalink.Manager
{
    public class Manager_SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}