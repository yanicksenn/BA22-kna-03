using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Utility
{
    public class LocationTrigger : MonoBehaviour
    {
        [SerializeField] private Collider player;
        [SerializeField] private UnityEvent onEnterEvent = new UnityEvent();
        
        private void OnTriggerEnter(Collider other)
        {
            if(other == player)
                onEnterEvent.Invoke();
        }
    }
}