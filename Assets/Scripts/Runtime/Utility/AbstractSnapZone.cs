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


    public virtual bool Accepts(TS snappable)
    {
        return !IsSnapped;
    }
    
    public void Unsnap()
    {
        if (!IsSnapped)
            return;

        _snappedObject.UnsnapSoft();
        UnsnapSoft();
    }

    public void UnsnapSoft()
    {
        var tmpSnappedObject = _snappedObject;
        _snappedObject.OnGrab.RemoveListener(Unsnap);
        _snappedObject = null;
        GetUnsnapEvent().Invoke(tmpSnappedObject);
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

        if (!Accepts(snappable))
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
        {
            UnsnapSoft();
            return;
        }

        if (SnappedObject.IsGrabbed)
            return;

        if (!SnapReference.hasChanged)
            return;
            
        PlaceSnappedObject();
    }

    private void OnDestroy()
    {
        Unsnap();
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
