public class CableOutputConnector : Snappable<CableOutputConnector, CableOutputSnapZone>, IConductor
{
    public EnergyType GetEnergy()
    {
        if (SnapZone == null)
            return EnergyType.Invalid;

        return SnapZone.GetEnergy();
    }
}
