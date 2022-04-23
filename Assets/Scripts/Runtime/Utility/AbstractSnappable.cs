using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CollisionCache))]
public abstract class AbstractSnappable<TS, TZ> : Grabbable
    where TS : AbstractSnappable<TS, TZ> 
    where TZ : AbstractSnapZone<TS, TZ>
{
    [SerializeField]
    private GameObject preview;
    public GameObject Preview => preview;

    [SerializeField]
    private new Rigidbody rigidbody;
    public Rigidbody Rigidbody
    {
        get => rigidbody;
        set => rigidbody = value;
    }

    [SerializeField]
    private CollisionCache collisionCache;
    public CollisionCache CollisionCache
    {
        get => collisionCache;
        set => collisionCache = value;
    }

    [SerializeField] 
    private UnityEvent onSnap = new UnityEvent();
    public UnityEvent OnSnap => onSnap;

    [SerializeField] 
    private UnityEvent onUnsnap = new UnityEvent();
    public UnityEvent OnUnsnap => onUnsnap;


    private TZ _snapZone;
    public TZ SnapZone => _snapZone;

    
    public bool IsSnapped => _snapZone != null;

    private bool _couldBeSnapped;
    public bool CouldBeSnapped => _couldBeSnapped;

    public void Snap(TZ snapZone)
    {
        _snapZone = snapZone;
        rigidbody.isKinematic = true;
        OnSnap.Invoke();
    }

    public void Unsnap()
    {
        _snapZone = null;
        OnUnsnap.Invoke();
    }

    private void Update()
    {
        _couldBeSnapped = CollisionCache.GameObjects
            .Select(g => g.GetComponent<TZ>())
            .Where(c => c != null)
            .Any(c => c.Accepts((TS) this));
    }
}