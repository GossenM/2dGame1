using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject shurikenTop;
    [SerializeField] GameObject shurikenMiddle;
    [SerializeField] GameObject shurikenBottom;
       
    List<GameObject> pooledObjects = new List<GameObject>();

    int objectIndex;
    
    private void Awake()
    {
        for( int i = 0; i < 100; i++ )
        {
            pooledObjects.Add(Instantiate(shurikenTop));
            pooledObjects.Add(Instantiate(shurikenMiddle));
            pooledObjects.Add(Instantiate(shurikenBottom));
        }
    }

    public GameObject Get()
    {   
        objectIndex %= pooledObjects.Count;
        return pooledObjects[objectIndex++];
    }

    
}
