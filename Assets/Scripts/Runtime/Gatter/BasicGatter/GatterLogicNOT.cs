using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create NOT", fileName = "GatterLogicNOT")]
    public class GatterLogicNOT : AbstractGatterLogic
    {
        private void Awake()
        {
            LabelText = "NOT";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.All(e => e == EnergyType.True) ? EnergyType.False : EnergyType.True;
        }
    }
}