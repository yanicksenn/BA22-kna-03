using System.Linq;

public class XORGatter : AbstractGatter
{
    protected override void Awake()
    {
        LabelText = "XOR";
        base.Awake();
    }

    protected override EnergyType CalculateEnergy()
    {
        if (CableOutputSnapZones.Count(snapZone => snapZone.GetEnergy() == EnergyType.True) == 1)
            return EnergyType.True;

        return EnergyType.False;
    }
}