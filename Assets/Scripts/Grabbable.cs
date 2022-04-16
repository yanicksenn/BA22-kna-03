using UnityEditor;
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

    public bool IsGrabbed => isGrabbed; // || Selection.Contains(gameObject);

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        if (!enabled)
        {
            return;
        }
        base.GrabBegin(hand, grabPoint);
        OnGrab.Invoke();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        if (!enabled)
        {
            return;
        }
        base.GrabEnd(linearVelocity, angularVelocity);
        OnRelease.Invoke();
    }
}