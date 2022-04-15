using System.Linq;
using UnityEngine;

public class Gatter : Snappable<Gatter, GatterSnapZone>, IConductor
{
    [SerializeField]
    private CableInputSnapZone[] inputSnapZones;
    public CableInputSnapZone[] InputSnapZones
    {
        get => inputSnapZones;
        set => inputSnapZones = value;
    }

    [SerializeField] 
    private CableOutputSnapZone outputSnapZones;
    public CableOutputSnapZone OutputSnapZones
    {
        get => outputSnapZones;
        set => outputSnapZones = value;
    }

    public EnergyType GetEnergy()
    {
        if (inputSnapZones.Any(z => z.GetEnergy() == EnergyType.Invalid))
            return EnergyType.Invalid;

        if (inputSnapZones.All(z => z.GetEnergy() == EnergyType.True))
            return EnergyType.True;

        return EnergyType.False;
    }
}