using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObjectToLocation : MonoBehaviour
{
    private bool grabbed;
    private bool insideSnapZone;
    public bool snapped;
    
    [SerializeField] private GameObject ObjectToSnap;
    [SerializeField] private GameObject SnapRotationReference;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == ObjectToSnap.name)
        {
            insideSnapZone = true;
        }
        
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == ObjectToSnap.name)
        {
            insideSnapZone = false;
        }
        
    }

    void SnapObject()
    {
        if(grabbed == false && insideSnapZone == true)
        {
            ObjectToSnap.gameObject.transform.position = transform.position;
            ObjectToSnap.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            snapped = true;
        }
    }

    private void Update()
    {
        grabbed = ObjectToSnap.GetComponent<OVRGrabbable>().isGrabbed;
        SnapObject();
    }
}
