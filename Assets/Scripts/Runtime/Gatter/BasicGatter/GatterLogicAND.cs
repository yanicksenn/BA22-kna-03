using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create AND", fileName = "GatterLogicAND")]
    public class GatterLogicAND : AbstractGatterLogic
    {
        protected virtual void Awake()
        {
            LabelText = "AND";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.All(e => e == EnergyType.True) ? EnergyType.True : EnergyType.False;
        }
    }
}