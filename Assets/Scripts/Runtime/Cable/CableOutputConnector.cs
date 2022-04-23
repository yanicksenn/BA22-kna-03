using System.Collections.Generic;

public class CableOutputConnector : AbstractSnappable<CableOutputConnector, CableOutputSnapZone>, IConductor
{
    private Cable cable;

    private void Awake()
    {
        cable = GetComponentInParent<Cable>();
    }

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
