using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snap : MonoBehaviour
{
    private bool isGrab = false;
    public Transform player;
    private Transform[] objetos;
    private Material myMaterial; //Guardo el material del objeto por defecto
    public Material feedbackMaterial;
    public UnityEvent DoSnap;

    // Start is called before the first frame update
    void Start()
    {
        objetos = GetComponentsInChildren<Transform>();
        myMaterial = objetos[1].GetComponent<MeshRenderer>().material; //TODO LO QUE SEA RENDERER PINTA        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);

        if (distance < 1 && !isGrab)
        {
            OnHover();
            //Dar feedback visual
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnSelected();
            }

        }
        else if (distance > 1 && !isGrab)
        {
            //Dejo de dar feedback
            OnUnHover();
        }

        if (distance > 1 && !Input.GetKey(KeyCode.E))
        {
            //Suelto el Objeto
            OnReleased();
        }
    }

    private void OnHover()
    {
        objetos[1].GetComponent<MeshRenderer>().material = feedbackMaterial;
    }

    private void OnUnHover()
    {
        objetos[1].GetComponent<MeshRenderer>().material = myMaterial;
    }

    private void OnSelected()
    {
        this.transform.parent = player; //Paso la moneda al jugador, es decir lo emparento al jugador
        print("has cogido la moneda");
        this.transform.localPosition = new Vector3(0, 0, -0.2f); //Para que exista una distancia entre el juagdo y la moneda
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false; // lo sobreescribo por si lo velvo a coger q vuelva a no usar gravedad

        //Transform[] objetos = GetComponentsInChildren<Transform>(); //Pongo q es un array ya que te lo devuelve en un array en el orden en el que lo encuentra
        this.transform.localPosition = Vector3.zero;
        objetos[1].localPosition = objetos[2].localPosition;
        objetos[1].localRotation = objetos[2].localRotation;
        isGrab = true;
    }

    private void OnReleased()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true; //Para que cuando lo suelte se caiga al suelo
        print("has soltado la moneda");
        objetos[1].localPosition = Vector3.zero;
        objetos[1].localRotation = Quaternion.identity;
        isGrab = false;
        DoSnap.Invoke();
    }
}