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
            var snappable = other.GetComponent<Snappable>();
            if (snappable == null)
                return;

            if (_snappedObject == snappable && snappable.IsGrabbed)
            {
                _snappedObject.Unsnap();
                _snappedObject = null;
                return;
            }

            if (_snappedObject != null || snappable.IsGrabbed) 
                return;
            
            _snappedObject = snappable;
            _snappedObject.Snap();
                
            var snappedtransform = _snappedObject.transform;
            snappedtransform.position = snapReference.position;
            snappedtransform.rotation = snapReference.rotation;
        }
    }
}