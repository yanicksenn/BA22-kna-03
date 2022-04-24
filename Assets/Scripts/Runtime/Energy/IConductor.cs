using UnityEngine.Events;

public interface IConductor : IDependable
{
    EnergyType GetEnergy();

    UnityEvent GetEnergyChangeEvent();
}