using UnityEngine;

public class CableInputConnector : AbstractSnappable<CableInputConnector, CableInputSnapZone>
{
    [SerializeField]
    private Cable cable;

    public Cable Cable
    {
        get => cable;
        set => cable = value;
    }
}
