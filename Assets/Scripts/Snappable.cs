using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CollisionCache))]
public abstract class Snappable<TS, TZ> : Grabbable
    where TS : Snappable<TS, TZ> 
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

    private TZ _snapZone;
    public TZ SnapZone => _snapZone;

    
    public bool IsSnapped => _snapZone != null;

    private bool _couldBeSnapped;
    public bool CouldBeSnapped => _couldBeSnapped;

    public void Snap(TZ snapZone)
    {
        _snapZone = snapZone;
        rigidbody.isKinematic = true;
    }

    public void Unsnap()
    {
        _snapZone = null;
    }

    private void Update()
    {
        _couldBeSnapped = CollisionCache.GameObjects
            .Select(g => g.GetComponent<TZ>())
            .Where(c => c != null)
            .Any(c => c.Accepts((TS) this));
    }
}