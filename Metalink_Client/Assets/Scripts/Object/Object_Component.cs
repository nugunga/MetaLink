using UnityEngine;

namespace Metalink.Object
{
    public abstract class MetalinkComponent : MetalinkObject
    {
        public MetalinkComponent() : base() { }
        public Transform transform { get; }
        public GameObject gameObject { get; }

        public T GetComponent<T>()
        {
            if (gameObject.TryGetComponent<T>(out T component))
                return component;
            throw new System.NullReferenceException("Component does not exist");
        }

        public T GetComponentChilderen<T>()
        {
            foreach (Transform child in transform) {
                if (child.TryGetComponent<T>(out T component)) {
                    return component;
                }
            }
            throw new System.NullReferenceException("Component does not exist");
        }
    }
}