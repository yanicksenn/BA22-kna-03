using UnityEngine;

[RequireComponent(typeof(Grabbable))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Snappable<TS, TZ> : MonoBehaviour 
    where TS : Snappable<TS, TZ> 
    where TZ : AbstractSnapZone<TS, TZ>
{
    [SerializeField]
    private GameObject preview;
    public GameObject Preview => preview;

    [SerializeField]
    private Grabbable grabbable;
    public Grabbable Grabbable
    {
        get => grabbable;
        set => grabbable = value;
    }

    [SerializeField]
    private new Rigidbody rigidbody;
    public Rigidbody Rigidbody
    {
        get => rigidbody;
        set => rigidbody = value;
    }

    private TZ _snapZone;
    public TZ SnapZone => _snapZone;

    public bool IsGrabbed => grabbable.isGrabbed;
    public bool IsSnapped => _snapZone != null;
    
    public void Snap(TZ snapZone)
    {
        _snapZone = snapZone;
        rigidbody.isKinematic = true;
    }

    public void Unsnap()
    {
        _snapZone = null;
    }
}