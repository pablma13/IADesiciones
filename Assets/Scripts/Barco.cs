using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco : MonoBehaviour
{
    public Vector3 nextPosition;
    private Vector3 initialPosition = new Vector3();
    private bool navegado = false;

    private void Start()
    {
        initialPosition = GetComponent<Transform>().position;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 metaPosition;
        if(navegado) metaPosition = initialPosition;
        else  metaPosition = nextPosition;

        navegado = !navegado;

        StartCoroutine(ExampleCoroutine(metaPosition, collision));
    }

    IEnumerator ExampleCoroutine(Vector3 metaPosition, Collision collision)
    {
        collision.transform.position = metaPosition + new Vector3(0.0f, 1.3f, 0.0f);

        yield return new WaitForSeconds(0.3f);

        this.transform.position = metaPosition;
    }

}
