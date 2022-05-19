using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.GatterDispenser
{
    [CreateAssetMenu(menuName = "BA22/Create Gatterlist", fileName = "Gatterlist")]
    public class GatterList : ScriptableObject
    {
        private List<GatterLabel> gatters = new List<GatterLabel>();
        [SerializeField] private UnityEvent addedGatterToList = new UnityEvent();
        public UnityEvent AddedGatterToList => addedGatterToList;

        public List<GatterLabel> Gatters => gatters;

        public void AddGatterIfNew(GatterLabel gatter)
        {
            if (gatters.Contains(gatter)) 
                return;
            
            gatters.Add(gatter);
            addedGatterToList.Invoke();
        }

        public void Reset()
        {
            gatters.Clear();
            addedGatterToList.Invoke();
        }
    }
}