using System.Collections.Generic;
using UnityEngine;

public class CableOutputConnector : AbstractSnappable<CableOutputConnector, CableOutputSnapZone>, IConductor
{
    [SerializeField]
    private Cable cable;

    public IEnumerable<IDependable> GetDirectDependencies()
    {
        return new List<IDependable> { cable };
    }

    public EnergyType GetEnergy()
    {
        if (cable == null)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;
        
        return cable.GetEnergy();
    }
}
