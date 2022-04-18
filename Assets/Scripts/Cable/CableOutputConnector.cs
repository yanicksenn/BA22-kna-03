public class CableOutputConnector : Snappable<CableOutputConnector, CableOutputSnapZone>
{
    public EnergyType GetEnergy()
    {
        if (SnapZone == null)
            return EnergyType.Invalid;

        return SnapZone.GetEnergy();
    }
}
