
using System.Collections.Generic;

public class CableOutputSnapZone : AbstractSnapZone<CableOutputConnector, CableOutputSnapZone>, IConductor
{
    public IEnumerable<IDependable> GetDirectDependencies()
    {
        if (SnappedObject == null)
            return new List<IDependable>();

        return new List<IDependable> { SnappedObject };
    }

    public EnergyType GetEnergy()
    {
        if (SnappedObject == null)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        return SnappedObject.GetEnergy();
    }
}
