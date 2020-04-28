using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publico : MonoBehaviour
{
    public bool miedo = false;
    public Vector3 huida;
    private Vector3 escenario;

    private void Awake()
    {
        escenario = GetComponent<Transform>().position;
    }

    private void Update()
    {
        if(miedo) this.transform.position = huida;
        else this.transform.position = escenario;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lampara"))
        {
            miedo = true;
        }
    }

    public void calma()
    {
        miedo = false;
    }
}
