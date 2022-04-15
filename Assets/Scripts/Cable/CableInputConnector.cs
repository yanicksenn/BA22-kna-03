using UnityEngine;

public class CableInputConnector : Snappable<CableInputConnector, CableInputSnapZone>, IConductor
{
    [SerializeField]
    private Cable cable;
    public Cable Cable
    {
        get => cable;
        set => cable = value;
    }

    public EnergyType GetEnergy()
    {
        return Cable.GetEnergy();
    }
}
