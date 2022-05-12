using Runtime.Presentation;
using UnityEngine;

namespace Runtime.Tutorial
{
    public class TutorialHighlighter : MonoBehaviour
    {
        [SerializeField] 
        private Presenter presenter;

        [SerializeField]
        private AbstractTutorialSlide tutorialSlide;

        [SerializeField] 
        private bool prohibitAutomaticNext;

        private void Awake()
        {
            tutorialSlide.SlideEvents.OnShowEvent.AddListener(Activate);
            tutorialSlide.SlideEvents.OnHideEvent.AddListener(Deactivate);
            
            // Presenter shows first slide on Start()
            Deactivate();
        }

        private void OnDestroy()
        {
            tutorialSlide.SlideEvents.OnShowEvent.RemoveListener(Activate);
            tutorialSlide.SlideEvents.OnHideEvent.RemoveListener(Deactivate);
        }

        private void Activate()
        {
            tutorialSlide.TutorialEvent.OnInvocation += TutorialEventInvoked;
            gameObject.SetActive(true);
        }

        private void TutorialEventInvoked()
        {
            Deactivate();
            ShowNextSlideOnPresenterIfPossible();
        }

        private void Deactivate()
        {
            tutorialSlide.TutorialEvent.OnInvocation -= TutorialEventInvoked;
            gameObject.SetActive(false);
        }

        private void ShowNextSlideOnPresenterIfPossible()
        {
            if (presenter == null)
                return;
            
            if (prohibitAutomaticNext)
                return;
            
            presenter.Next();
        }
    }
}