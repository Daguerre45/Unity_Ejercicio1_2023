using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZOne : MonoBehaviour
{
    public GameObject monedsToSnap;
    private bool monedaIsReadyToSnap;

    private void Start()
    {
        monedaIsReadyToSnap = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == monedsToSnap)
        {
            monedaIsReadyToSnap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == monedsToSnap)
        {
            monedaIsReadyToSnap = false;
        }
    }

    public void SnapMoneda()
    {
        if(monedaIsReadyToSnap)
        {
            monedsToSnap.transform.parent = this.transform;
            monedsToSnap.transform.localPosition = Vector3.zero;
            monedsToSnap.GetComponent<Rigidbody>().isKinematic = true;
            monedsToSnap.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}

