
using UnityEngine;

public class CableOutputSnapZone : AbstractSnapZone<CableOutputConnector, CableOutputSnapZone>, IConductor
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
        return Gatter.GetEnergy();
    }
}
