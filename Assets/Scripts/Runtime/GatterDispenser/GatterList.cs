using System.Collections.Generic;
using UnityEngine;

namespace Runtime.GatterDispenser
{
    [CreateAssetMenu(menuName = "BA22/Create Gatterlist", fileName = "Gatterlist")]
    public class GatterList : ScriptableObject
    {
        [SerializeField] private List<GameObject> gatters = new List<GameObject>();

        public List<GameObject> Gatters => gatters;

        public void AddGatterIfNew(GameObject gatter)
        {
            if (!gatters.Contains(gatter))
                gatters.Add(gatter);
        }
    }
}