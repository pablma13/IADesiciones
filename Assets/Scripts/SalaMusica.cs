using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaMusica : MonoBehaviour
{
    public GameObject PertenenciasDelFantasma;
    //public Vector3 secreto;
    //private Vector3 paredNormal;

    //private void Awake()
    //{
    //    paredNormal = GetComponent<Transform>().position;
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fantasma"))
        {
            PertenenciasDelFantasma.transform.position = new Vector3(PertenenciasDelFantasma.transform.position.x,
                                                                      -0.75f,
                                                                      PertenenciasDelFantasma.transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fantasma"))
        {
            PertenenciasDelFantasma.transform.position = new Vector3(PertenenciasDelFantasma.transform.position.x,
                                                                     0.5f,
                                                                     PertenenciasDelFantasma.transform.position.z);
        }
    }
}
