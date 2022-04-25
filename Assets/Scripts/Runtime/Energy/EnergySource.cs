using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergySource : MonoBehaviour, IConductor
{
    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;
    
    private EnergyType energyType = EnergyType.False;

    public void enableCurrent()
    {
        ChangeEnergy(EnergyType.True);
    }

    public void disableCurrent()
    {
        ChangeEnergy(EnergyType.False);
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        return new List<IDependable>();
    }

    private void ChangeEnergy(EnergyType energyType)
    {
        if (this.energyType == energyType) 
            return;
        
        this.energyType = energyType;
        GetEnergyChangeEvent().Invoke();
    }

    public EnergyType GetEnergy()
    {
        return energyType;
    }

    public UnityEvent GetEnergyChangeEvent()
    {
        return onEnergyChangeEvent;
    }
}
