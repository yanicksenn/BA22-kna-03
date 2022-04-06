using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    [SerializeField] private GameObject SnapLocation;
    [SerializeField] private GameObject board;
    public bool isSnapped;
    private bool objectSnapped;
    private bool grabbed;

    private void Update()
    {
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;
        objectSnapped = SnapLocation.GetComponent<SnapObjectToLocation>().snapped;

        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(board.transform);
            isSnapped = true;
        }

        if (objectSnapped == false && grabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
