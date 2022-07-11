using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Metalink.BackEnd;

using TMPro;

namespace Metalink.UI
{
    public class UI_Register : UI_UserBase
    {
        [SerializeField] private BackEnd_Register m_Register;

        [Space(10)]
        [SerializeField] private Canvas m_LogInUI;
        [SerializeField] private Canvas m_RegisterUI;

        [Space(10)]
        [SerializeField] private TMP_InputField m_UsernameInput;
        [SerializeField] private TMP_InputField m_ConfirmPasswordInput;

        [Space(10)]
        [SerializeField] private string m_ConfirmFailedAlterText = "Confirm password does not match.";

        void Awake()
        {
            m_ConfirmButton.onClick.AddListener(CheckConfirmPassword);

            m_Register.m_RegisterSuccessEvent += (result) => {
                RegisterSuccess();
                UIReset();
            };

            m_Register.m_RegisterFailureEvent += (result) => {
                m_Alter.Active(m_FailureAlterText);
                UIReset();
            };
        }

        public void CheckConfirmPassword()
        {
            if (m_PasswordInput.text == m_ConfirmPasswordInput.text)
                m_Register.Register(m_EmailInput.text, m_PasswordInput.text, m_UsernameInput.text);
            else
                m_Alter.Active(m_ConfirmFailedAlterText);
        }

        public void RegisterSuccess()
        {
            m_LogInUI.enabled = true;
            m_RegisterUI.enabled = false;
            m_Alter.Active(m_SuccessAlterText);
        }

        public override void UIReset()
        {
            base.UIReset();
            m_UsernameInput.text = "";
            m_ConfirmPasswordInput.text = "";
        }
    }
}