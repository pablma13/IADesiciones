using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosasDelFantasma : MonoBehaviour
{
    public GameObject PertenenciasDelFantasma;
    public bool destrosado = false;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Conde"))
        {
            destrosado = true;
        }
        else if (collision.gameObject.CompareTag("Fantasma"))
        {
            destrosado = false;
        }
        PertenenciasDelFantasma.SetActive(!destrosado);
    }
}
