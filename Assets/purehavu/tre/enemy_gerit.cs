using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class enemy_gerit : MonoBehaviour
{
    [SerializeField] private uint PoolSize;
    [SerializeField]private PooledObject<GameObject> Object;

    private Stack<PooledObject<GameObject>> stack;

    private void Start()
    {
        SetupPool();
    }

    private void SetupPool() 
    {
        stack = new Stack<PooledObject<GameObject>>();
      

    }


}
