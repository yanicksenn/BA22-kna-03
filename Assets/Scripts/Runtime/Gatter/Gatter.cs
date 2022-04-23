using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gatter : AbstractSnappable<Gatter, GatterSnapZone>, IConductor
{
    [SerializeField] 
    private CableOutputSnapZone[] cableOutputSnapZones;

    public IEnumerable<IDependable> GetDirectDependencies()
    {
        return cableOutputSnapZones;
    }

    public EnergyType GetEnergy()
    {
        if (SnapZone == null)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        if (cableOutputSnapZones.All(d => d.GetEnergy() == EnergyType.True))
            return EnergyType.False;

        return EnergyType.True;
    }
}