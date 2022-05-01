using System.Linq;

public class NOTGatter : AbstractGatter
{
    protected override void Awake()
    {
        LabelText = "NOT";
        base.Awake();
    }

    protected override EnergyType CalculateEnergy()
    {
        if (CableOutputSnapZones.Any(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.False;

        return EnergyType.True;
    }
}