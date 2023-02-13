using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool isGrab = false;
    public Transform player;
    private Transform objeto;
    private Material myMaterial; //Guardo el material del objeto por defecto
    public Material feedbackMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material; //TODO LO QUE SEA RENDERER PINTA        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);

        if (distance<1 && !isGrab )
        {
            OnHover();
            //Dar feedback visual
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnSelected();
            }
        }else if(distance > 1 && !isGrab)
        {
            //Dejo de dar feedback
            OnUnHover();
        }

        if(isGrab && !Input.GetKey(KeyCode.E))
        {
            //Suelto el Objeto
            OnReleased();
        }
    }

    private void OnHover()
    {
        this.GetComponent<MeshRenderer>().material = feedbackMaterial;
    }

    private void OnUnHover()
    {
        this.GetComponent<MeshRenderer>().material = myMaterial;
    }

    private void OnSelected()
    {
        this.transform.parent = player; //Paso la moneda al jugador, es decir lo emparento al jugador
        this.transform.localPosition = new Vector3(0, 0, -0.2f); //Para que exista una distancia entre el juagdo y la moneda
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false; // lo sobreescribo por si lo velvo a coger q vuelva a no usar gravedad
    }

    private void OnReleased()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true; //Para que cuando lo suelte se caiga al suelo
    }
}
