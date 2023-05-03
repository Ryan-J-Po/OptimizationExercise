using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool
    {
        private string _name;
        private List<GameObject> _objects;

        public Pool(string name, GameObject gameObject)
        {
            _name = name;
            _objects = new List<GameObject>();
            _objects.Add(gameObject);
        }

        public string Name
        {
            get { return _name; }
        }

        public int Count 
        { 
            get 
            { 
                return _objects.Count; 
            } 
        }

        public GameObject GetObject()
        {
            if (_objects.Count == 0)
            {
                return null;
            }

            GameObject gameObject = _objects[0];
            _objects.RemoveAt(0);

            return gameObject;
        }

        public void ReturnObject(GameObject gameObject)
        {
            _objects.Add(gameObject);
        }
    }
}
