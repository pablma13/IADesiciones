using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

public class Sala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Fantasma"))
        {
            var tree = other.gameObject.GetComponent<BehaviorTree>();
            SharedInt counter = (SharedInt) tree.GetVariable("Counter");
            
            SharedGameObjectList prueba = (SharedGameObjectList) tree.GetVariable("LastVisitedRooms");
            if ( (GameObject) tree.GetVariable("CurrentLocation").GetValue() != gameObject)
            {
                
                tree.GetVariable("CurrentLocation").SetValue(gameObject);
                prueba.Value[counter.Value] = gameObject;
                counter.Value = (counter.Value + 1)%prueba.Value.Capacity;
            }

        }
    }
}
