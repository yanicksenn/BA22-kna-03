using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create FAO1", fileName = "GatterLogicFAO1")]
    public class GatterLogicFAO1 : AbstractGatterLogic
    {
        private void Awake()
        {
            LabelText = "O1";
        }

        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.Count(e => e == EnergyType.True) > 1 ? EnergyType.True : EnergyType.False;
        }
    }
}