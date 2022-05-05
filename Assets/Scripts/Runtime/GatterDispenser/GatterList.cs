using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.GatterDispenser
{
    [CreateAssetMenu(menuName = "BA22/Create Gatterlist", fileName = "Gatterlist")]
    public class GatterList : ScriptableObject
    {
        private List<GameObject> gatters = new List<GameObject>();
        [SerializeField] private UnityEvent addedGatterToList = new UnityEvent();
        public UnityEvent AddedGatterToList => addedGatterToList;

        public List<GameObject> Gatters => gatters;

        public void AddGatterIfNew(GameObject gatter)
        {
            if (!gatters.Contains(gatter))
            {
                gatters.Add(gatter);
                addedGatterToList.Invoke();
            }
        }
    }
}