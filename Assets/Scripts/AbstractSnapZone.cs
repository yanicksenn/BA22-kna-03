using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AbstractSnapZone<TS, TZ> : MonoBehaviour 
    where TS : Snappable<TS, TZ> 
    where TZ : AbstractSnapZone<TS, TZ>
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
    
    private GameObject _preview;


    public bool Accepts(TS snappable)
    {
        return SnappedObject == null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        var snappable = other.GetComponent<TS>();
        if (snappable == null)
            return;

        if (_snappedObject != null)
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

    public void Unsnap()
    {
        if (_snappedObject == null)
            return;
        
        _snappedObject.OnGrab.RemoveListener(Unsnap);
        _snappedObject.Unsnap();
        _snappedObject = null;
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

    private void LateUpdate()
    {
        if (_snappedObject != null && _snappedObject.IsGrabbed == false)
            PlaceSnappedObject();
    }

    private void PlaceSnappedObject()
    {
        var snappedtransform = _snappedObject.transform;
        snappedtransform.position = snapReference.position;
        snappedtransform.rotation = snapReference.rotation;
    }
}
