using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(OVRGrabbable))]
    [RequireComponent(typeof(Rigidbody))]
    public class Snappable : MonoBehaviour
    {
        private OVRGrabbable _grabbable;
        private Rigidbody _rigidbody;

        public bool IsGrabbed => _grabbable.isGrabbed;

        private void Awake()
        {
            _grabbable = GetComponent<OVRGrabbable>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Snap()
        {
            _rigidbody.isKinematic = true;
        }

        public void Unsnap()
        {
            _rigidbody.isKinematic = false;
        }
    }
}