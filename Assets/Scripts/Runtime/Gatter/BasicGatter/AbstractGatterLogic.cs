using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    public abstract class AbstractGatterLogic : ScriptableObject
    {
        [SerializeField]
        private string labelText;
        public string LabelText
        {
            get => labelText;
            set => labelText = value;
        }

        public abstract EnergyType CalculateEnergy(List<EnergyType> energyTypes);
    }
}