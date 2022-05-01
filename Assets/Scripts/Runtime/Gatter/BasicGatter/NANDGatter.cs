using System.Linq;

public class NANDGatter : AbstractGatter
{
    protected override void Awake()
    {
        LabelText = "NAND";
        base.Awake();
    }

    protected override EnergyType CalculateEnergy()
    {
        if (CableOutputSnapZones.All(snapZone => snapZone.GetEnergy() == EnergyType.True))
            return EnergyType.False;

        return EnergyType.True;
    }
}