using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour, IConductor
{
    [SerializeField] private EnergyType energy;
    public EnergyType Energy
    {
        get => energy;
        set => energy = value;
    }

    public EnergyType GetEnergy()
    {
        return energy;
    }

    public void enableCurrent()
    {
        energy = EnergyType.True;
    }

    public void disableCurrent()
    {
        energy = EnergyType.False;
    }
    
}
