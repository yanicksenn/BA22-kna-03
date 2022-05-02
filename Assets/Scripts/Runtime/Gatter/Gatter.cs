using System.Collections.Generic;
using System.Linq;
using Runtime.Gatter.BasicGatter;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Gatter : AbstractSnappable<Gatter, GatterSnapZone, GatterEvent, GatterSnapZoneEvent>, IConductor
{
    [SerializeField] 
    private AbstractGatterLogic gatterLogic;
    public AbstractGatterLogic GatterLogic
    {
        get => gatterLogic;
        set => gatterLogic = value;
    }

    [SerializeField] 
    private TMP_Text label;
    public TMP_Text Label
    {
        get => label;
        set => label = value;
    }

    [SerializeField]
    private CableOutputSnapZone[] cableOutputSnapZones;
    public CableOutputSnapZone[] CableOutputSnapZones
    {
        get => cableOutputSnapZones;
        set => cableOutputSnapZones = value;
    }

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

    protected override void Awake()
    {
        base.Awake();

        if (label != null)
            label.text = GatterLogic.LabelText;
    }

    private void OnEnable()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.AddListener(OnEnergyChange);
        
        OnSnapToBoard.AddListener(OnEnergyChange);
        OnUnsnapFromBoard.AddListener(OnEnergyChange);
        
    }

    private void OnDisable()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
        
        OnSnapToBoard.RemoveListener(OnEnergyChange);
        OnUnsnapFromBoard.RemoveListener(OnEnergyChange);
        
    }

    private void OnEnergyChange()
    {
        var newEnergyType = RecalcEnergy();
        if (newEnergyType == energyType)
            return;
        
        energyType = newEnergyType;
        GetEnergyChangeEvent().Invoke();
        
    }

    private void OnEnergyChange(GatterSnapZone gatterSnapZone)
    {
        OnEnergyChange();
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
        
        if (cableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.Invalid))
            return EnergyType.Invalid;

        var energyTypes = cableOutputSnapZones.Select(z => z.GetEnergy()).ToList();
        return GatterLogic.CalculateEnergy(energyTypes);
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