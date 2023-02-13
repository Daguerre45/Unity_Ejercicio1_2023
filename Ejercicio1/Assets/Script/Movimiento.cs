using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform agentePerseguido; //coge solo la variable transfor de agenteperseguido. Se puede hacer tbn con GameObject y luego abajo llamar a transform.position
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.autoBraking = false;
        /*
        agente.destination = Vector3.zero;
        bool estoyPendienteDeRecibirDestin0 = agente.pathPending;
        float distanciaAlDestino = agente.remainingDistance;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                agente.destination = hit.point;
            }
        }*/

        agente.destination = agentePerseguido.position;
    }
}
