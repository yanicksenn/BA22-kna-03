using System.Linq;

public class ORGatter : AbstractGatter
{
    protected override void Awake()
    {
        LabelText = "OR";
        base.Awake();
    }

    protected override EnergyType CalculateEnergy()
    {
        if (CableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.True;

        return EnergyType.False;
    }
}