using UnityEngine;

namespace Runtime.Tutorial
{
    public class TutorialHighlighter : MonoBehaviour
    {
        [SerializeField]
        private TutorialSlide tutorialSlide;
        public TutorialSlide TutorialSlide
        {
            get => tutorialSlide;
            set => tutorialSlide = value;
        }

        private void Awake()
        {
            tutorialSlide.SlideEvents.OnShowEvent.AddListener(Activate);
            tutorialSlide.SlideEvents.OnHideEvent.AddListener(Deactivate);
        }

        private void OnDestroy()
        {
            tutorialSlide.SlideEvents.OnShowEvent.RemoveListener(Activate);
            tutorialSlide.SlideEvents.OnHideEvent.RemoveListener(Deactivate);
        }

        private void Activate()
        {
            tutorialSlide.TutorialEvent.OnInvocation += Deactivate;
            gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            tutorialSlide.TutorialEvent.OnInvocation -= Deactivate;
            gameObject.SetActive(false);
        }
    }
}