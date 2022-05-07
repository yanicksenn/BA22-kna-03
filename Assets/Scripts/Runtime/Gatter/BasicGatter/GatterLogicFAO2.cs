﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create FAO2", fileName = "GatterLogicFAO2")]
    public class GatterLogicFAO2 : AbstractGatterLogic
    {
        private void Awake()
        {
            LabelText = "O2";
        }
        public override EnergyType CalculateEnergy(List<EnergyType> energyTypes)
        {
            return energyTypes.Count(e => e == EnergyType.True) % 2 == 1  ? EnergyType.True : EnergyType.False;
        }
    }
}