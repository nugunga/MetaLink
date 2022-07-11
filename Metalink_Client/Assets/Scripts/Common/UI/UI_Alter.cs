using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Metalink.UI
{
    public class UI_Alter : MonoBehaviour
    {
        [SerializeField] private Canvas m_ThisCanvas;
        [SerializeField] private TextMeshProUGUI m_AlterText;

        public void Active(string m_Alter)
        {
            m_ThisCanvas.enabled = true;
            m_AlterText.text = m_Alter;
        }
    }
}
