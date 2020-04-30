using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class CosasDelFantasma : MonoBehaviour
{
    public GameObject PertenenciasDelFantasma;
    public bool destrosado = false;

    private void OnCollisionEnter(Collision collision)
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
        var destroyed = (SharedBool) GlobalVariables.Instance.GetVariable("MusicBoxBroken");
        destroyed.Value = destrosado;
    }
}
