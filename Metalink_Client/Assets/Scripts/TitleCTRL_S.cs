using System.Collections.Generic;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine;

using Metalink.BackEnd;

public class TitleCTRL_S : MonoBehaviour
{
    [SerializeField] private BackEnd_LogIn m_LogIn;

    public void Awake()
    {
        m_LogIn.m_LoginSuccessEvent += (result) => SceneManager.LoadScene("Lobby");
    }
}
