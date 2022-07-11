using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Metalink.BackEnd;

using TMPro;

namespace Metalink.UI
{
    public class UI_LogIn : UI_UserBase
    {
        [SerializeField] private BackEnd_LogIn m_Login;

        public void Awake()
        {
            m_ConfirmButton.onClick.AddListener(() => {
                m_Login.LogIn(m_EmailInput.text, m_PasswordInput.text);
            });

            m_Login.m_LoginFailureEvent += (result) => {
                m_Alter.Active(result.GenerateErrorReport());
            };
        }
    }
}