using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertas : MonoBehaviour
{
    public GameObject puerta;

    private void OnCollisionStay(Collision collision)
    {
        puerta.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        puerta.SetActive(true);
    }
}
