using Runtime.Presentation;
using UnityEngine;

namespace Runtime.Tutorial
{
    public class TutorialManager : MonoBehaviour, INavigationInterceptor
    {
        [SerializeField] private Presenter presenter;

        private bool _canContinue;
        
        public bool AllowsNext(AbstractSlide slide)
        {
            if (slide is TutorialSlide)
                return _canContinue;

            return true;
        }

        public void OnShowSlide(AbstractSlide slide)
        {
            if (slide is TutorialSlide tutorialSlide)
                tutorialSlide.TutorialEvent.OnInvocation += OnInvoke;

            _canContinue = false;
        }

        private void OnInvoke()
        {
            _canContinue = true;
        }

        public void OnHideSlide(AbstractSlide slide)
        {
            if (slide is TutorialSlide tutorialSlide)
                tutorialSlide.TutorialEvent.OnInvocation -= OnInvoke;
        }

        private void OnEnable()
        {
            presenter.NavigationConditions.Add(this);
        }
    
        private void OnDisable()
        {
            presenter.NavigationConditions.Remove(this);
        }
    }
}