using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0) //Devuelve 1 si es la positiva (W y flecha pa arriba), Devuelve -1 en caso contrario y 0 si no se pulsa nada
        {
            transform.Translate(0,0, Input.GetAxis("Vertical")*0.1f);
        }

        if (Input.GetAxis("Horizontal") != 0) //Devuelve 1 si es la positiva (D y flecha derecha), Devuelve -1 en caso contrario y 0 si no se pulsa nada
        {
            transform.Translate(Input.GetAxis("Horizontal") * 0.1f, 0, 0);
        }

    }
}
