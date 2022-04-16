
using UnityEngine;

public class CableInputSnapZone : AbstractSnapZone<CableInputConnector, CableInputSnapZone>, IConductor
{
    public EnergyType GetEnergy()
    {
        return EnergyType.Invalid;
    }
}
