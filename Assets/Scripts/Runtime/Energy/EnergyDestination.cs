using System.Collections.Generic;
using UnityEngine;

public class EnergyDestination : MonoBehaviour, IConductor
{
    private const string TriggerName = "LightBulbTrigger";
    private static readonly int LightBulbTrigger = Animator.StringToHash(TriggerName);
    
    [SerializeField]
    private CableOutputSnapZone cableOutputSnapZone;
    
    [SerializeField]
    private Lightbulb lightbulb;

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

    public IEnumerable<IDependable> GetDirectDependencies()
    {
        if (cableOutputSnapZone == null)
            return new List<IDependable>();

        return new List<IDependable> { cableOutputSnapZone };
    }

    public EnergyType GetEnergy()
    {
        if (cableOutputSnapZone == null)
            return EnergyType.Invalid;

        return cableOutputSnapZone.GetEnergy();
    }
}
