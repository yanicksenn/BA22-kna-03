using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create OR", fileName = "GatterLogicOR")]
    public class GatterLogicOR : AbstractGatterLogic
    {
        private void Awake()
        {
            LabelText = "OR";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.Any(e => e == EnergyType.True) ? EnergyType.True : EnergyType.False;
        }
    }
}