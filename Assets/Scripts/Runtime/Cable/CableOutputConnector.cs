using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CableOutputConnector : AbstractSnappable<CableOutputConnector, CableOutputSnapZone, CableOutputConnectorEvent, CableOutputSnapZoneEvent>, IConductor
{
    [SerializeField]
    private Cable cable;

    [SerializeField, Space] 
    private CableOutputSnapZoneEvent onConnect = new CableOutputSnapZoneEvent();
    public CableOutputSnapZoneEvent OnConnect => onConnect;

    [SerializeField] 
    private CableOutputSnapZoneEvent onDisconnect = new CableOutputSnapZoneEvent();

    public CableOutputSnapZoneEvent OnDisconnect => onDisconnect;

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;

    private EnergyType energyType = EnergyType.Invalid;

    public IEnumerable<IDependable> GetDependencies()
    {
        return new List<IDependable> { cable };
    }

    private void OnEnable()
    {
        cable.OnEnergyChangeEvent.AddListener(OnEnergyChange);
    }

    private void OnDisable()
    {
        cable.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
    }

    private void OnEnergyChange()
    {
        var newEnergyType = RecalcEnergy();
        if (newEnergyType == energyType) 
            return;
        
        energyType = newEnergyType;
        GetEnergyChangeEvent().Invoke();
    }

    public EnergyType RecalcEnergy()
    {
        if (cable == null)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;
        
        return cable.GetEnergy();
    }
    
    public EnergyType GetEnergy()
    {
        return energyType;
    }

    public override CableOutputSnapZoneEvent GetSnapEvent()
    {
        return OnConnect;
    }

    public override CableOutputSnapZoneEvent GetUnsnapEvent()
    {
        return OnDisconnect;
    }

    public UnityEvent GetEnergyChangeEvent()
    {
        return onEnergyChangeEvent;
    }
}
