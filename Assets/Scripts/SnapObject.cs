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

    private OVRGrabbable _grabbable;
    private SnapObjectToLocation _snapLocation;

    private void Awake()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        _snapLocation = SnapLocation.GetComponent<SnapObjectToLocation>();
    }

    private void Update()
    {
        var grabbed = _grabbable.isGrabbed;
        var objectSnapped = _snapLocation.snapped;
        
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
