using UnityEngine;

namespace Runtime.Utility
{
    public class SFXManager : MonoBehaviour
    {
        [SerializeField] private AudioSource snap;
        [SerializeField] private AudioSource buttonClick;
        [SerializeField] private AudioSource toggle;
        [SerializeField] private AudioSource cableSnap;
        [SerializeField] private AudioSource cableUnSnap;

        public void PlaySnapSound()
        {
            snap.Play();
        }

        public void PlayButtonClickSound()
        {
            buttonClick.Play();
        }
        
        public void PlayToggleSound()
        {
            toggle.Play();
        }

        public void PlayCableSnapSound()
        {
            cableSnap.Play();
        }

        public void PlayCableUnsnapSound()
        {
            cableUnSnap.Play();
        }
    }
}