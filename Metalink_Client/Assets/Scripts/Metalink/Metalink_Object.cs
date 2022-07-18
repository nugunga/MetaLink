using System.Collections.Generic;
using System;

namespace Metalink
{
    public abstract class MetalinkObject
    {
        protected Dictionary<string, object> attributes;

        public MetalinkObject()
        {
            AddAttribute("ObjectId", Guid.NewGuid().ToString());
            attributes = new Dictionary<string, object>();
        }

        public static bool operator ==(MetalinkObject o1, MetalinkObject o2) => o1.GetAttribute<string>("ObjectId") == o2.GetAttribute<string>("ObjectId");
        public static bool operator !=(MetalinkObject o1, MetalinkObject o2) => o1.GetAttribute<string>("ObjectId") != o2.GetAttribute<string>("ObjectId");

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();

        public void AddAttribute<T>(string p_AttributeName, T value) => attributes.Add(p_AttributeName, value);
        public void SetAttribute<T>(string p_AttributeName, T value) => attributes[p_AttributeName] = value;
        public T GetAttribute<T>(string p_AttributeName) => (T)attributes[p_AttributeName];
        public virtual void RemoveAttribute(string p_AttributeName) => attributes.Remove(p_AttributeName);

        public MetalinkObject FindObject(string p_ObjectId)
        {
            if (GetAttribute<string>("ObjectId") == p_ObjectId)
                return this;
            return null;
        }
    }
}
