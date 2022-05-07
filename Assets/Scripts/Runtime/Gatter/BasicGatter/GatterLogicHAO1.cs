using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gatter.BasicGatter
{
    [CreateAssetMenu(menuName = "BA22/Gatter Logic/Create HAO1", fileName = "GatterLogicHAO1")]
    public class GatterLogicHAO1 : GatterLogicAND
    {
        protected override void Awake()
        {
            LabelText = "O1";
        }
    }
}