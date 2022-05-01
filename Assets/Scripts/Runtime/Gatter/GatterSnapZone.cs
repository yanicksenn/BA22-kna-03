
using UnityEngine;

public class GatterSnapZone : AbstractSnapZone<AbstractGatter, GatterSnapZone, GatterEvent, GatterSnapZoneEvent>
{
    [SerializeField]
    private GatterEvent onSnapEvent = new GatterEvent();
    public GatterEvent OnSnapEvent => onSnapEvent;

    [SerializeField]
    private GatterEvent onUnsnapEvent = new GatterEvent();
    public GatterEvent OnUnsnapEvent => onUnsnapEvent;

    public override GatterEvent GetSnapEvent()
    {
        return onSnapEvent;
    }

    public override GatterEvent GetUnsnapEvent()
    {
        return onUnsnapEvent;
    }
}