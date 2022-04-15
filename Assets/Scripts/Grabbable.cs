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

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        OnGrab.Invoke();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        OnRelease.Invoke();
    }
}