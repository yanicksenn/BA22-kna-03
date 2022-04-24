using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CollisionCache))]
public abstract class AbstractSnappable<TS, TZ, TES, TEZ> : Grabbable
    where TS : AbstractSnappable<TS, TZ, TES, TEZ> 
    where TZ : AbstractSnapZone<TS, TZ, TES, TEZ>
    where TES : UnityEvent<TS>
    where TEZ : UnityEvent<TZ>
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

    private TZ _snapZone;
    public TZ SnapZone => _snapZone;

    
    public bool IsSnapped => _snapZone != null;

    private bool _couldBeSnapped;
    public bool CouldBeSnapped => _couldBeSnapped;

    public void Snap(TZ snapZone)
    {
        _snapZone = snapZone;
        rigidbody.isKinematic = true;
        GetSnapEvent().Invoke(snapZone);
    }

    public void Unsnap()
    {
        var tmpSnapZone = _snapZone;
        _snapZone = null;
        
        GetUnsnapEvent().Invoke(tmpSnapZone);
    }

    public abstract TEZ GetSnapEvent();
    public abstract TEZ GetUnsnapEvent();

    private void Update()
    {
        _couldBeSnapped = CollisionCache.GameObjects
            .Select(g => g.GetComponent<TZ>())
            .Where(c => c != null)
            .Any(c => c.Accepts((TS) this));
    }
}