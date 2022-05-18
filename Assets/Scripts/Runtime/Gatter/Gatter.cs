using System.Collections.Generic;
using System.Linq;
using Runtime.Gatter.BasicGatter;
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
    private CableOutputSnapZone[] cableOutputSnapZones;

    [SerializeField, Space]
    private GatterSnapZoneEvent onSnapToBoard = new GatterSnapZoneEvent();
    public GatterSnapZoneEvent OnSnapToBoard => onSnapToBoard;

    [SerializeField]
    private GatterSnapZoneEvent onUnsnapFromBoard = new GatterSnapZoneEvent();
    public GatterSnapZoneEvent OnUnsnapFromBoard => onUnsnapFromBoard;

    [SerializeField, Space] 
    private UnityEvent onEnergyChangeEvent = new UnityEvent();
    public UnityEvent OnEnergyChangeEvent => onEnergyChangeEvent;
    
    /// <summary>
    /// Returns of any of the co-existing gatters has been snapped.
    /// </summary>
    public bool IsAnySnapped => coExistingGatters.Any(g => g.IsSnapped);

    private EnergyType energyType = EnergyType.Invalid;
    private GatterLabel gatterLabel;
    private Gatter[] coExistingGatters;
    private Cable[] cables;

    public bool HasCoExistingGatters => coExistingGatters != null && coExistingGatters.Length > 1;

    protected override void Awake()
    {
        base.Awake();
        gatterLabel = GetComponentInParent<GatterLabel>();
        coExistingGatters = GetComponents<Gatter>();
        cables = gatterLabel.GetComponentsInChildren<Cable>();
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Destroy(gatterLabel.gameObject);
        
        foreach (var cable in cables)
            Destroy(cable.gameObject);
    }

    private void AddListeners()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.AddListener(OnEnergyChange);
        
        foreach (var gatter in coExistingGatters) {
            gatter.OnSnapToBoard.AddListener(OnEnergyChange);
            gatter.OnUnsnapFromBoard.AddListener(OnEnergyChange);
        }
    }

    private void RemoveListeners()
    {
        foreach (var cableOutputSnapZone in cableOutputSnapZones)
            cableOutputSnapZone.OnEnergyChangeEvent.RemoveListener(OnEnergyChange);
        
        foreach (var gatter in coExistingGatters) {
            gatter.OnSnapToBoard.RemoveListener(OnEnergyChange);
            gatter.OnUnsnapFromBoard.RemoveListener(OnEnergyChange);
        }
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
        if (!IsCurrentOrCoExistingGatterSnapped())
        {
            return EnergyType.Invalid;
        }

        if (DependableUtil.HasCyclicDependencies(this))
        {
            return EnergyType.Invalid;
        }

        if (cableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.Invalid))
        {
            return EnergyType.Invalid;
        }

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

    private bool IsCurrentOrCoExistingGatterSnapped()
    {
        return IsSnapped || HasCoExistingGatters && coExistingGatters.Any(g => g.IsSnapped);
    }
}