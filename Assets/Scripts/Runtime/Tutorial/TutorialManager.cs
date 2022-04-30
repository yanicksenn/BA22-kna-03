using Runtime.Presentation;
using UnityEngine;

namespace Runtime.Tutorial
{
    public class TutorialManager : MonoBehaviour, INavigationCondidition
    {
        [SerializeField] private Presenter presenter;
        public bool AllowsNext(AbstractSlide slide)
        {
            return false;
        }

        public bool AllowsPrevious(AbstractSlide slide)
        {
            return false;
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