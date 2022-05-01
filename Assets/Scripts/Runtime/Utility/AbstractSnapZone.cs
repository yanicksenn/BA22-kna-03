using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class AbstractSnapZone<TS, TZ, TES, TEZ> : MonoBehaviour 
    where TS : AbstractSnappable<TS, TZ, TES, TEZ> 
    where TZ : AbstractSnapZone<TS, TZ, TES, TEZ>
    where TES : UnityEvent<TS>
    where TEZ : UnityEvent<TZ>
{
    [SerializeField] 
    private Transform snapReference;
    public Transform SnapReference
    {
        get => snapReference;
        set => snapReference = value;
    }

    private TS _snappedObject;
    public TS SnappedObject => _snappedObject;
    public bool IsSnapped => SnappedObject != null;
    
    private GameObject _preview;


    public bool Accepts(TS snappable)
    {
        return SnappedObject == null;
    }
    
    public void Unsnap()
    {
        if (!IsSnapped)
            return;

        var tmpSnappedObject = _snappedObject;
        _snappedObject.Unsnap();
        
        UnsnapLocalObject();
        GetUnsnapEvent().Invoke(tmpSnappedObject);
    }

    private void UnsnapLocalObject()
    {
        _snappedObject.OnGrab.RemoveListener(Unsnap);
        _snappedObject = null;
    }

    public abstract TES GetSnapEvent();
    public abstract TES GetUnsnapEvent();
    
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        var snappable = other.GetComponent<TS>();
        if (snappable == null)
            return;

        if (IsSnapped)
            return;

        if (snappable.IsGrabbed)
        {
            ShowPreview(snappable);
            return;
        }

        HidePreview();

        _snappedObject = snappable;
        _snappedObject.OnGrab.AddListener(Unsnap);
        _snappedObject.Snap((TZ) this);

        PlaceSnappedObject();
        GetSnapEvent().Invoke(_snappedObject);
    }

    private void OnTriggerExit(Collider other)
    {
        var snappable = other.GetComponent<TS>();
        if (snappable == null)
            return;

        if (!snappable.IsGrabbed)
            return;
        
        HidePreview();
    }

    private void ShowPreview(TS snappable)
    {
        if (_preview != null)
            return;

        var preview = snappable.Preview;
        if (preview == null) 
            return;
        
        _preview = Instantiate(preview, snapReference.position, snapReference.rotation);
    }

    private void HidePreview()
    {
        if (_preview == null)
            return;
        
        Destroy(_preview);
        _preview = null;
    }

    private void Update()
    {
        if (!IsSnapped)
            return;

        // If two snap zones could accept the same object at the same time
        // then both might get snapped while only one should be snapped.
        if (SnappedObject.SnapZone != this || !SnappedObject.IsSnapped)
            UnsnapLocalObject();

        if (SnappedObject.IsGrabbed)
            return;

        if (!SnapReference.hasChanged)
            return;
            
        PlaceSnappedObject();
    }

    private void PlaceSnappedObject()
    {
        var snappedtransform = _snappedObject.transform;
        snappedtransform.position = snapReference.position;
        snappedtransform.rotation = snapReference.rotation;
        
        // Set this to false manually because unity does not figure this
        // out themselves.
        snapReference.hasChanged = false;
    }
}
