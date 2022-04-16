
public class CableOutputSnapZone : AbstractSnapZone<CableOutputConnector, CableOutputSnapZone>, IConductor
{
    public EnergyType GetEnergy()
    {
        return EnergyType.Invalid;
    }
}
