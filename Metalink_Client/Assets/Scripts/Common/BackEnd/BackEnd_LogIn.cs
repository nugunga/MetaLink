using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;
using UnityEngine;

namespace Metalink.BackEnd
{
    public class BackEnd_LogIn : MonoBehaviour
    {
        public UnityAction<LoginResult> m_LoginSuccessEvent;
        public UnityAction<PlayFabError> m_LoginFailureEvent;

        public void LogIn(string p_Email, string p_Password)
        {
            var request = new LoginWithEmailAddressRequest { Email = p_Email , Password = p_Password };
            PlayFabClientAPI.LoginWithEmailAddress(request, m_LoginSuccessEvent.Invoke, m_LoginFailureEvent.Invoke);
        }
    }
}