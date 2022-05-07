using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create HAO2", fileName = "GatterLogicHAO2")]
    public class GatterLogicHAO2 : GatterLogicXOR
    {
        protected override void Awake()
        {
            LabelText = "O2";
        }
    }
}