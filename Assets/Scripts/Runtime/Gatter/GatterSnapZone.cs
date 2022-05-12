
using UnityEngine;

public class GatterSnapZone : AbstractSnapZone<Gatter, GatterSnapZone, GatterEvent, GatterSnapZoneEvent>
{
    [SerializeField]
    private GatterEvent onSnapEvent = new GatterEvent();

    [SerializeField]
    private GatterEvent onUnsnapEvent = new GatterEvent();

    public override GatterEvent GetSnapEvent()
    {
        return onSnapEvent;
    }

    public override GatterEvent GetUnsnapEvent()
    {
        return onUnsnapEvent;
    }
}