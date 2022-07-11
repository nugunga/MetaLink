using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;
using UnityEngine;

namespace Metalink.BackEnd
{
    public class BackEnd_Register : MonoBehaviour
    {
        public UnityAction<RegisterPlayFabUserResult> m_RegisterSuccessEvent;
        public UnityAction<PlayFabError> m_RegisterFailureEvent;

        public void Register(string p_Email, string p_Password, string p_Username)
        {
            var request = new RegisterPlayFabUserRequest { Email = p_Email, Password = p_Password, Username = p_Username };
            PlayFabClientAPI.RegisterPlayFabUser(request, m_RegisterSuccessEvent.Invoke, m_RegisterFailureEvent.Invoke);
        }
    }
}