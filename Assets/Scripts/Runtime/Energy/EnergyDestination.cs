using System.Collections.Generic;
using UnityEngine;

public class EnergyDestination : MonoBehaviour, IConductor
{
    private const string TriggerName = "LightBulbTrigger";
    private static readonly int LightBulbTrigger = Animator.StringToHash(TriggerName);
    
    [SerializeField]
    private CableOutputSnapZone cableOutputSnapZone;
    private Animator _lightbulbAnimator;

    private void Awake()
    {
        _lightbulbAnimator = GetComponent<Animator>();
    }

    public void turnOnLightbulb()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
    }

    public void turnOffLightbulb()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
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
