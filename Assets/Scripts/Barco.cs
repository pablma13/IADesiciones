using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class Barco : MonoBehaviour
{
    public Vector3 nextPosition;
    private Vector3 initialPosition = new Vector3();
    private bool navegado = false;
    private bool ocupado = false;

    private void Start()
    {
        initialPosition = GetComponent<Transform>().position;
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        
        if (!ocupado)
        {
            GameObject collidedObject = collision.gameObject;
            BehaviorTree aux = collidedObject.GetComponent<BehaviorTree>();
            if (aux != null)
            {
                aux.PauseWhenDisabled = true;
                aux.enabled = false;
            }
            yield return new WaitForSeconds(0.1f);
            ocupado = true;
            Vector3 metaPosition;
            if(navegado) metaPosition = initialPosition;
            else  metaPosition = nextPosition;

            navegado = !navegado;

            
            collidedObject.GetComponent<Rigidbody>().position = metaPosition + new Vector3(0.0f, 1.3f, 0.0f);
            collidedObject.transform.position = metaPosition + new Vector3(0.0f, 1.3f, 0.0f);


            this.transform.position = metaPosition;

            if (aux != null)
                aux.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (ocupado)
            ocupado = false;
    }

    IEnumerator ExampleCoroutine(Vector3 metaPosition, Collision collision)
    {
        collision.transform.position = metaPosition + new Vector3(0.0f, 1.3f, 0.0f);

        yield return new WaitForSeconds(0.1f);

        this.transform.position = metaPosition;
    }

}
