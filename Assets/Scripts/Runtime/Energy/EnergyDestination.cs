using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnergyDestination : MonoBehaviour, IConductor
{
    [SerializeField] private string text;
    [SerializeField] private TMP_Text label;
    
    [SerializeField]
    private CableOutputSnapZone cableOutputSnapZone;
    
    [SerializeField]
    private Lightbulb lightbulb;
    
    [SerializeField, Space]
    private CableOutputConnectorEvent onConnect = new CableOutputConnectorEvent();

    [SerializeField]
    private CableOutputConnectorEvent onDisonnect = new CableOutputConnectorEvent();

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();

    private EnergyType energyType = EnergyType.Invalid;

    private void Awake()
    {
        if (cableOutputSnapZone == null)
            Debug.LogError("cable output snap zone is missing", this);
        
        if (lightbulb == null)
            Debug.LogError("lightbulb is missing", this);

        if (label != null)
            label.text = text;
    }

    private void OnEnable()
    {
        cableOutputSnapZone.OnEnergyChangeEvent.AddListener(OnEnergyChange);
        OnEnergyChange();
    }

    private void OnDisable()
    {
        cableOutputSnapZone.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
        OnEnergyChange();
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
        if (!cableOutputSnapZone.IsSnapped)
            return EnergyType.Invalid;

        return cableOutputSnapZone.GetEnergy();
    }

    public IEnumerable<IDependable> GetDependencies()
    {
        return new List<IDependable> { cableOutputSnapZone };
    }

    private void Update()
    {
        var energy = GetEnergy();
        if (ShouldTurnOn(energy) || ShouldTurnOff(energy))
            lightbulb.Toggle();
    }

    private bool ShouldTurnOff(EnergyType energy)
    {
        return energy is EnergyType.False or EnergyType.Invalid && lightbulb.IsOn;
    }

    private bool ShouldTurnOn(EnergyType energy)
    {
        return energy == EnergyType.True && !lightbulb.IsOn;
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
