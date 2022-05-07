using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create XOR", fileName = "GatterLogicXOR")]
    public class GatterLogicXOR : AbstractGatterLogic
    {
        protected  virtual void Awake()
        {
            LabelText = "XOR";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.Count(e => e == EnergyType.True) == 1 ? EnergyType.True : EnergyType.False;
        }
    }
}