using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gatter : AbstractSnappable<Gatter, GatterSnapZone>, IConductor
{
    [SerializeField] 
    private CableOutputSnapZone[] cableOutputSnapZones;

    public IEnumerable<IDependable> GetDependencies()
    {
        return cableOutputSnapZones;
    }

    public EnergyType GetEnergy()
    {
        if (SnapZone == null)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        if (cableOutputSnapZones.All(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.False;

        if (cableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.Invalid))
            return EnergyType.Invalid;

        return EnergyType.True;
    }
}