using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create NAND", fileName = "GatterLogicNAND")]
    public class GatterLogicNAND : AbstractGatterLogic
    {
        private void Awake()
        {
            LabelText = "NAND";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.All(e => e == EnergyType.True) ? EnergyType.False : EnergyType.True;
        }
    }
}