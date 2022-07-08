using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using BackEnd;

namespace Metalink.BackEnd
{
    public class BackEnd_ServerManager : MonoBehaviour
    {
        public UnityEvent m_InitializeSuccesEvent;
        public UnityEvent<string> m_InitializeFailEvent;

        public UnityEvent m_SignInSuccesEvent;
        public UnityEvent<string> m_SignInFailEvent;

        public UnityEvent m_LogInSuccesEvent;
        public UnityEvent<string> m_LogInFailEvent;

        public void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            // 첫 번째 방법 (동기)
            var l_bro = Backend.Initialize(true);
            if (l_bro.IsSuccess()) {
                m_InitializeSuccesEvent.Invoke();
            }
            else {
                m_InitializeFailEvent.Invoke(l_bro.ToString());
            }
        }

        public void SignUp(string p_Id, string p_Password)
        {
            var l_bro = Backend.BMember.CustomSignUp(p_Id, p_Password);
            if (l_bro.IsSuccess()) {
                m_SignInSuccesEvent.Invoke();
            }
            else {
                m_LogInFailEvent.Invoke(l_bro.ToString());
            }
        }

        public void LogIn(string p_Id, string p_Password)
        {
            var l_bro = Backend.BMember.CustomLogin(p_Id, p_Password);
            if (l_bro.IsSuccess()) {
                m_LogInSuccesEvent.Invoke();
            }
            else {
                m_SignInFailEvent.Invoke(l_bro.ToString());
            }
        }
    }
}