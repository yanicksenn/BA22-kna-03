using System.Linq;

public class ANDGatter : AbstractGatter
{
    protected override void Awake()
    {
        LabelText = "AND";
        base.Awake();
    }

    protected override EnergyType CalculateEnergy()
    {
        if (CableOutputSnapZones.All(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.True;

        return EnergyType.False;
    }
}