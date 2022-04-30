using Runtime.Presentation;
using UnityEngine;


namespace Runtime.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialSlide", menuName = "BA22/Slide/Create new tutorial slide")]
    public class TutorialSlide : TextSlide
    {
        [SerializeField, Space] private Events.Event tutorialEvent;
        public Events.Event TutorialEvent => tutorialEvent;
    }
}