using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPoolBehaviour : MonoBehaviour
    {
        private List<Pool> _objectPools;
        private static ObjectPoolBehaviour _instance;

        public static ObjectPoolBehaviour Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ObjectPoolBehaviour>();
                }

                if (_instance == null)
                {
                    GameObject objectPool = new GameObject("Object Pool");
                    _instance = objectPool.AddComponent<ObjectPoolBehaviour>();
                }

                return _instance;
            }
        }

        public Pool GetPool(GameObject gameObject)
        {
            foreach (Pool pool in _objectPools)
            {
                if (pool.Name == gameObject.name)
                {
                    return pool;
                }

            }
            return null;
        }
        
        public GameObject GetObject(GameObject gameObject)
        {
            Pool objectPool = GetPool(gameObject);

            if (objectPool != null && objectPool.Count > 0)
            {

            }
        }
    }
}
