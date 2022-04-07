using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(OVRGrabbableExtension))]
    [RequireComponent(typeof(Rigidbody))]
    public class Snappable : MonoBehaviour
    {
        [SerializeField]
        private GameObject preview;
        public GameObject Preview => preview;

        private OVRGrabbableExtension _grabbable;
        public OVRGrabbableExtension Grabbable => _grabbable;
        private Rigidbody _rigidbody;

    public bool IsGrabbed => _grabbable.isGrabbed;

        private void Awake()
        {
            _grabbable = GetComponent<OVRGrabbableExtension>();
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Snap()
        {
            _rigidbody.isKinematic = true;
        }
    }
}