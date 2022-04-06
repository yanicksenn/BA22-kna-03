using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Collider))]
    public class SnapZone : MonoBehaviour
    {
        [SerializeField] 
        private Transform snapReference;
        
        private Snappable _snappedObject;

        private void OnTriggerStay(Collider other)
        {
            if (_snappedObject != null)
                return;

            var snappable = other.GetComponent<Snappable>();
            if (snappable == null)
                return;

            if (snappable.IsGrabbed)
                return;

            _snappedObject = snappable;
            _snappedObject.Snap(this);
            
            var snappedtransform = _snappedObject.transform;
            snappedtransform.position = snapReference.position;
            snappedtransform.rotation = snapReference.rotation;
        }

        public void Unsnap()
        {
            if (_snappedObject != null)
                return;

            _snappedObject = null;
        }
    }
}