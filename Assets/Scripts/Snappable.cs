using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(OVRGrabbable))]
    [RequireComponent(typeof(Rigidbody))]
    public class Snappable : MonoBehaviour
    {
        private OVRGrabbable _grabbable;
        private Rigidbody _rigidbody;

        private SnapZone _snapZone;

        public bool IsGrabbed => _grabbable.isGrabbed;

        private void Awake()
        {
            _grabbable = GetComponent<OVRGrabbable>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Snap(SnapZone snapZone)
        {
            if (_snapZone != null)
                return;
            
            _snapZone = snapZone;

            if (_rigidbody != null)
                _rigidbody.isKinematic = false;
        }

        public void Unsnap()
        {
            if (_snapZone != null)
                _snapZone.Unsnap();
            
            _snapZone = null;
            
            if (_rigidbody != null) 
                _rigidbody.isKinematic = true;
        }
    }
}