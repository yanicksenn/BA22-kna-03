using UnityEngine;
using UnityEngine.Events;

public class Grabbable : OVRGrabbable
{
    [SerializeField]
    private UnityEvent onGrab = new UnityEvent();
    public UnityEvent OnGrab => onGrab;

    [SerializeField]
    private UnityEvent onRelease = new UnityEvent();
    public UnityEvent OnRelease => onRelease;

    [SerializeField] 
    private bool isActive = true;
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    public bool IsGrabbed => isGrabbed; // || Selection.Contains(gameObject);
    
    
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        if (!IsActive)
            return;
        
        base.GrabBegin(hand, grabPoint);
        OnGrab.Invoke();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        if (!IsActive)
            return;
        
        base.GrabEnd(linearVelocity, angularVelocity);
        OnRelease.Invoke();
    }
}