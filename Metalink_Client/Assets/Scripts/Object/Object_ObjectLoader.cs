using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Metalink.Object
{
    [System.Serializable]
    public struct TransfromData
    {
        public string m_Id;
        public float[] m_Position;
        public float[] m_Rotation;
        public float[] m_Scale;

        public void SetTransform(Transform p_Transform)
        {
            p_Transform.position = new Vector3(m_Position[0], m_Position[1], m_Position[2]);
            p_Transform.rotation = Quaternion.Euler(m_Rotation[0], m_Rotation[1], m_Rotation[2]);
            p_Transform.localScale = new Vector3(m_Scale[0], m_Scale[1], m_Scale[2]);
        }

        public override string ToString()
        {
            Vector3 postion = new Vector3(m_Position[0], m_Position[1], m_Position[2]);
            Vector3 rotation = new Vector3(m_Rotation[0], m_Rotation[1], m_Rotation[2]);
            Vector3 scale = new Vector3(m_Scale[0], m_Scale[1], m_Scale[2]);
            return postion.ToString() + "\n" + rotation.ToString() + "\n" + scale.ToString();
        }
    }

    [System.Serializable]
    public struct ResourceData
    {
        public string m_Type;
        public string m_Script;
        public string m_Name;
        public string m_Src;
        public string m_JsonData;

        public override string ToString() => $"type : {m_Type}, script : {m_Script}, name : {m_Name}, src : {m_Src}, m_JsonData : {m_JsonData}";
    }

    [System.Serializable]
    public class ObjectLoadData
    {
        public TransfromData[] m_Positions;
        public Dictionary<string, ResourceData> m_Resources;
        public string m_RowData;
    }

    public class Object_ObjectLoader : MonoBehaviour
    {
        [ContextMenu("Load")]
        public void LoadObject()
        {
            TextAsset mytxtData = (TextAsset)Resources.Load("sample");
            ObjectLoadData l_objectLoadData = JsonConvert.DeserializeObject<ObjectLoadData>(mytxtData.text);

            string result = "";

            foreach (TransfromData data in l_objectLoadData.m_Positions) {
                result += $"{data}\n";
            }

            foreach (var data in l_objectLoadData.m_Resources) { 
                result += $"{data.Key} : {data.Value}\n";
            }

            result += l_objectLoadData.m_RowData;

            print(result);
        }
    }
}