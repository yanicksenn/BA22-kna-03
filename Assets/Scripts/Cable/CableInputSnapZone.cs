
using UnityEngine;

public class CableInputSnapZone : AbstractSnapZone<CableInputConnector, CableInputSnapZone>, IConductor
{
    [SerializeField]
    private Gatter gatter;
    public Gatter Gatter
    {
        get => gatter;
        set => gatter = value;
    }

    public EnergyType GetEnergy()
    {
        if (SnappedObject == null)
            return EnergyType.Invalid;

        return SnappedObject.GetEnergy();
    }
}
