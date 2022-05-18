using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
        SetEnergy(EnergyType.True);
    }

    public void disableCurrent()
    {
        SetEnergy(EnergyType.False);
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        return new List<IDependable>();
    }
    
    public void SetEnergy(int energy)
    {
        SetEnergy(energy == 1 ? EnergyType.True : EnergyType.False);
    }

    public void SetEnergy(EnergyType energyType)
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
