using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour, IConductor
{
    [SerializeField] private EnergyType energy;

    public void enableCurrent()
    {
        energy = EnergyType.True;
        Debug.Log($"BA22 enableCurrent ${energy}");
    }

    public void disableCurrent()
    {
        energy = EnergyType.False;
        Debug.Log($"BA22 disableCurrent ${energy}");
    }

    public IEnumerable<IDependable> GetDirectDependencies()
    {
        return new List<IDependable>();
    }

    public EnergyType GetEnergy()
    {
        return energy;
    }
}
