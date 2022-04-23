using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour, IConductor
{
    [SerializeField] private EnergyType energy;

    public void enableCurrent()
    {
        energy = EnergyType.True;
    }

    public void disableCurrent()
    {
        energy = EnergyType.False;
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        return new List<IDependable>();
    }

    public EnergyType GetEnergy()
    {
        return energy;
    }
}
