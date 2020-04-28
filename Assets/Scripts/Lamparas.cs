using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamparas : MonoBehaviour
{
    public GameObject lamparaCaida;
    public Publico p;
    public bool roto = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fantasma"))
        {
            roto = true;
        }
        else if (collision.gameObject.CompareTag("Conde"))
        {
            roto = false;
            p.calma();
        }
        lamparaCaida.SetActive(roto);
    }
}
