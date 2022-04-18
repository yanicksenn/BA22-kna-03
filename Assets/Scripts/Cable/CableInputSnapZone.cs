
using UnityEngine;

public class CableInputSnapZone : AbstractSnapZone<CableInputConnector, CableInputSnapZone>
{
    public EnergyType GetEnergy()
    {
        return EnergyType.Invalid;
    }
}
