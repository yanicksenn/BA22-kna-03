using Runtime.Presentation;
using UnityEngine;

namespace Runtime.Tutorial
{
    public abstract class AbstractTutorialSlide: AbstractSlide
    {
        [SerializeField, Space] private Events.Event tutorialEvent;
        public Events.Event TutorialEvent => tutorialEvent;
    }
}