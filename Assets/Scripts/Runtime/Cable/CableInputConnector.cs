using UnityEngine;

public class CableInputConnector : Snappable<CableInputConnector, CableInputSnapZone>
{
    [SerializeField]
    private Cable cable;

    public Cable Cable
    {
        get => cable;
        set => cable = value;
    }
}
