using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CableOutputSnapZone : AbstractSnapZone<CableOutputConnector, CableOutputSnapZone, CableOutputConnectorEvent, CableOutputSnapZoneEvent>, IConductor
{
    [SerializeField, Tooltip("This is just relevant for snap zones on gatter. It can be null on other objects.")] 
    private Gatter gatter;
    public Gatter Gatter
    {
        get => gatter;
        set => gatter = value;
    }

    [SerializeField]
    private CableOutputConnectorEvent onSnapEvent = new CableOutputConnectorEvent();
    public CableOutputConnectorEvent OnSnapEvent => onSnapEvent;

    [SerializeField]
    private CableOutputConnectorEvent onUnsnapEvent = new CableOutputConnectorEvent();
    public CableOutputConnectorEvent OnUnsnapEvent => onUnsnapEvent;

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;

    private EnergyType energyType;

    private void OnEnable()
    {
        OnSnapEvent.AddListener(OnSnap);
        OnUnsnapEvent.AddListener(OnUnsnap);
    }

    private void OnDisable()
    {
        OnSnapEvent.RemoveListener(OnSnap);
        OnUnsnapEvent.RemoveListener(OnUnsnap);
    }

    public override bool Accepts(CableOutputConnector snappable)
    {
        // Accept snappables only if not snapped yet
        if (!base.Accepts(snappable))
            return false;

        // If owning element is a gatter and is not snapped
        // then dont accept it.
        if (Gatter != null && !Gatter.IsSnapped)
            return false;

        // Cable does not belong to gatter
        if (snappable.Cable.Gatter == null)
            return true;
        
        // Don't allow to snap with itself
        return snappable.Cable.Gatter != Gatter;
    }

    private void OnSnap(CableOutputConnector cableOutputConnector)
    {
        cableOutputConnector.OnEnergyChangeEvent.AddListener(OnEnergyChange);
        OnEnergyChange();
    }

    private void OnUnsnap(CableOutputConnector cableOutputConnector)
    {
        cableOutputConnector.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
        OnEnergyChange();
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        if (!IsSnapped) 
            return new List<IDependable>() ;
        
        return new List<IDependable> { SnappedObject };
    }

    private void OnEnergyChange()
    {
        var newEnergyType = RecalcEnergy();
        if (newEnergyType == energyType) 
            return;
        
        energyType = newEnergyType;
        GetEnergyChangeEvent().Invoke();
    }

    private EnergyType RecalcEnergy()
    {
        if (!IsSnapped)
            return EnergyType.Invalid;
        
        if (DependableUtil.HasCyclicDependencies(this))
            return EnergyType.Invalid;

        return SnappedObject.GetEnergy();
    }
    
    public EnergyType GetEnergy()
    {
        return energyType;
    }

    public override CableOutputConnectorEvent GetSnapEvent()
    {
        return onSnapEvent;
    }

    public override CableOutputConnectorEvent GetUnsnapEvent()
    {
        return onUnsnapEvent;
    }

    public UnityEvent GetEnergyChangeEvent()
    {
        return onEnergyChangeEvent;
    }
}
