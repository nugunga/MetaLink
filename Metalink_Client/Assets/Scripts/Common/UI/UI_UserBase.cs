using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace Metalink.UI
{
    public class UI_UserBase : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] protected TMP_InputField m_EmailInput;
        [SerializeField] protected TMP_InputField m_PasswordInput;
        [SerializeField] protected Button m_ConfirmButton;

        [Space(10)]
        [SerializeField] protected string m_SuccessAlterText = "Register succeed!";
        [SerializeField] protected string m_FailureAlterText = "Register failed, please check that the input is correct.";

        [Space(10)]
        [SerializeField] protected UI_Alter m_Alter;

        public virtual void UIReset()
        {
            m_EmailInput.text = "";
            m_PasswordInput.text = "";
        }
    }
}
