using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Gatter : AbstractSnappable<Gatter, GatterSnapZone, GatterEvent, GatterSnapZoneEvent>, IConductor
{
    [SerializeField]
    private CableOutputSnapZone[] cableOutputSnapZones;

    [SerializeField, Space]
    private GatterSnapZoneEvent onSnapToBoard = new GatterSnapZoneEvent();
    public GatterSnapZoneEvent OnSnapToBoard => onSnapToBoard;

    [SerializeField]
    private GatterSnapZoneEvent onUnsnapFromBoard = new GatterSnapZoneEvent();
    public GatterSnapZoneEvent OnUnsnapFromBoard => onUnsnapFromBoard;
    
    [SerializeField, Space]
    private CableOutputConnectorEvent onConnect = new CableOutputConnectorEvent();
    public CableOutputConnectorEvent OnConnect => onConnect;

    [SerializeField]
    private CableOutputConnectorEvent onDisonnect = new CableOutputConnectorEvent();
    public CableOutputConnectorEvent OnDisonnect => onDisonnect;

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;

    private EnergyType energyType = EnergyType.Invalid;

    private void OnEnable()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.AddListener(OnEnergyChange);
    }

    private void OnDisable()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
    }

    private void OnEnergyChange()
    {
        var newEnergyType = RecalcEnergy();
        if (newEnergyType == energyType) 
            return;
        
        energyType = newEnergyType;
        GetEnergyChangeEvent().Invoke();
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        return cableOutputSnapZones;
    }

    private EnergyType RecalcEnergy()
    {
        if (!IsSnapped)
            return EnergyType.Invalid;

        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        if (cableOutputSnapZones.All(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.False;

        if (cableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.Invalid))
            return EnergyType.Invalid;

        return EnergyType.True;
    }

    public EnergyType GetEnergy()
    {
        return energyType;
    }

    public override GatterSnapZoneEvent GetSnapEvent()
    {
        return onSnapToBoard;
    }

    public override GatterSnapZoneEvent GetUnsnapEvent()
    {
        return onUnsnapFromBoard;
    }

    public UnityEvent GetEnergyChangeEvent()
    {
        return onEnergyChangeEvent;
    }
}