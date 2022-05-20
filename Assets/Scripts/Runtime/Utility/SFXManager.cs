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
        [SerializeField] private AudioSource ambient;
        [SerializeField] private AudioSource shatter;
        [SerializeField] private AudioSource rightAnswer;
        [SerializeField] private AudioSource wrongAnswer;

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
            Debug.Log("BA22 Cable snap sound");
        }

        public void PlayCableUnsnapSound()
        {
            cableUnSnap.Play();
            Debug.Log("BA22 Cable unsnap sound");
        }

        public void PlayShatterSound()
        {
            shatter.Play();
        }

        public void PlayAmbientSound()
        {
            ambient.Play();
        }

        public void StopAmbientSound()
        {
            ambient.Stop();
        }

        public void PlayRightAnswer()
        {
            rightAnswer.Play();
        }

        public void PlayWrongAnswer()
        {
            wrongAnswer.Play();
        }
    }
}