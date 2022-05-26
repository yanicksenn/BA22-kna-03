using UnityEngine;

namespace Runtime.Utility
{
    public class GrabberHelper : MonoBehaviour
    {
        [SerializeField]
        private OVRGrabber leftGrabber;
       
        [SerializeField]
        private OVRGrabber rightGrabber;
        
        public void ReleaseGrabbers()
        {
            leftGrabber.GrabEnd();
            leftGrabber.Awake();
            leftGrabber.Start();
            
            rightGrabber.GrabEnd();
            rightGrabber.Awake();
            rightGrabber.Start();
        }
    }
}