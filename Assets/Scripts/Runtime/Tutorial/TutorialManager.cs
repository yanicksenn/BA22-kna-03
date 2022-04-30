using Runtime.Presentation;
using UnityEngine;

namespace Runtime.Tutorial
{
    public class TutorialManager : MonoBehaviour, INavigationCondidition
    {
        public bool AllowsNext(AbstractSlide slide)
        {
            return false;
        }

        public bool AllowsPrevious(AbstractSlide slide)
        {
            return false;
        }
    }
}