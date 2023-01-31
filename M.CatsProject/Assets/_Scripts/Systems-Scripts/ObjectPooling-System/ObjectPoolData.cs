using UnityEngine;

namespace _Scripts.ObjectPooling
{
    [CreateAssetMenu(fileName = "ObjectPooling", menuName = "PoolingData", order = 0)]
    public class ObjectPoolData : ScriptableObject
    {
        
        public string tag; // tag for the pool
        public GameObject prefab; // prefab for the objects in the pool
        public int size; // initial size of the pool
        public int maxSize; // maximum size of the pool (0 for unlimited)
    }
}