using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class Publico : MonoBehaviour
{
    public bool miedo = false;
    public Vector3 huida;
    public NavMeshAgent fantasma;
    private Vector3 escenario;
    private static int visiblePath = 13;
    private static int hiddenPath = 5;

    private void Awake()
    {
        if (hiddenPath == -2)
        {
            hiddenPath = NavMesh.GetAreaFromName("Walkable") | NavMesh.GetAreaFromName("Jump");
            visiblePath = hiddenPath | NavMesh.GetAreaFromName("Visible");
        }
            
        
        
        escenario = GetComponent<Transform>().position;
    }

    private void Update()
    {
        if(miedo) this.transform.position = huida;
        else this.transform.position = escenario;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lampara"))
        {
            miedo = true;
            fantasma.areaMask = visiblePath;
        }
    }

    public void calma()
    {
        miedo = false;
        fantasma.areaMask = hiddenPath;
        var aux = fantasma.path;
        fantasma.ResetPath();
        fantasma.SetPath(aux);
    }
}
