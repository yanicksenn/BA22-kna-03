using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Collider))]
    public class SnapZone : MonoBehaviour
    {
        [SerializeField] 
        private Transform snapReference;
        public Transform SnapReference
        {
            get => snapReference;
            set => snapReference = value;
        }


        private Snappable _snappedObject;
        private GameObject _preview;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerStay(other);
        }

        private void OnTriggerStay(Collider other)
        {
            var snappable = other.GetComponent<Snappable>();
            if (snappable == null)
                return;

            if (_snappedObject != null)
                return;

            if (snappable.IsGrabbed)
            {
                ShowPreview(snappable);
                return;
            }

            HidePreview();

            _snappedObject = snappable;
            _snappedObject.Grabbable.OnGrab.AddListener(OnGrab);
            _snappedObject.Snap();
            
            var snappedtransform = _snappedObject.transform;
            snappedtransform.position = snapReference.position;
            snappedtransform.rotation = snapReference.rotation;
        }

        private void OnTriggerExit(Collider other)
        {
            var snappable = other.GetComponent<Snappable>();
            if (snappable == null)
                return;

            if (!snappable.IsGrabbed)
                return;
            
            HidePreview();
        }

        private void OnGrab()
        {
            _snappedObject.Grabbable.OnGrab.RemoveListener(OnGrab);
            _snappedObject = null;
        }

        private void ShowPreview(Snappable snappable)
        {
            if (_preview != null)
                return;

            var preview = snappable.Preview;
            if (preview == null) 
                return;
            
            _preview = Instantiate(preview, snapReference.position, snapReference.rotation);
        }

        private void HidePreview()
        {
            if (_preview == null)
                return;
            
            Destroy(_preview);
            _preview = null;
        }
    }
}