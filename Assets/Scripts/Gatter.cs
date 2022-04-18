using UnityEngine;

public class Gatter : Snappable<Gatter, GatterSnapZone>
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
}