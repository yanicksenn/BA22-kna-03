using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]
public class EnergySource : MonoBehaviour, IConductor
{
    [SerializeField] private string text;
    [SerializeField] private TMP_Text label;
    
    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;

    private EnergyType energyType = EnergyType.False;

    private void Awake()
    {
        if (label != null)
            label.text = text;
    }

    public void enableCurrent()
    {
        ChangeEnergy(EnergyType.True);
    }

    public void disableCurrent()
    {
        ChangeEnergy(EnergyType.False);
    }
    
    public void setCurrent(int energy)
    {
        if(energy ==1)
            ChangeEnergy(EnergyType.True);
        else
        {
            ChangeEnergy(EnergyType.False);
        }
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
