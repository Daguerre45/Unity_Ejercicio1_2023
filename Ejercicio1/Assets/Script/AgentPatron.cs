using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentPatron : MonoBehaviour
{
    private NavMeshAgent agente;
    public GameObject agente2;
    public Transform[] destinos;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.autoBraking = false; //Porque no quiero que decelere su velocidad al aproximarse el destino
    }

    // Update is called once per frame
    void Update()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.1f) //pathPending si le ha llegado un destino al que acudir
        {
            AsignarDestino();
        }
    }

    
    private void AsignarDestino()
    {
        /*if (i == destinos.Length)
        {
            i = 0;
        }
            
        agente.destination = destinos[i].position; //Ojo al ser un array de trnasforms hay que asignarle siempre una posición
        i++;*/
        agente.destination = agente2.transform.position;

    }
}
