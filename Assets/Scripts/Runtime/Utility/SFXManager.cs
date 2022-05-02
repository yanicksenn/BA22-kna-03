using UnityEngine;

namespace Runtime.Utility
{
    public class SFXManager : MonoBehaviour
    {
        [SerializeField] private AudioSource snap;
        [SerializeField] private AudioSource buttonClick;

        public void PlaySnapSound()
        {
            snap.Play();
        }

        public void PlayButtonClickSound()
        {
            buttonClick.Play();
        }
    }
}