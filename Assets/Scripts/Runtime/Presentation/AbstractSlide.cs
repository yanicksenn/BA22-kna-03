using System;
using UnityEngine;

namespace Runtime.Presentation
{
    public abstract class AbstractSlide : ScriptableObject
    {
        [SerializeField] 
        private string title;
        public string Title
        {
            get => title;
            set => title = value;
        }

        [SerializeField, Space] 
        private ButtonConfiguration nextButton = new ButtonConfiguration("Next");
        public ButtonConfiguration NextButton => nextButton;
        
        [SerializeField] 
        private ButtonConfiguration previousButton = new ButtonConfiguration("Previous");
        public ButtonConfiguration PreviousButton => previousButton;

        [SerializeField, Space] 
        private SlideEvents slideEvents = new SlideEvents();
        public SlideEvents SlideEvents => slideEvents;
  
        private bool firstTimeShowed;

        private void OnEnable()
        {
            SlideEvents.OnShowEvent.AddListener(OnShow);
        }

        private void OnDisable()
        {
            SlideEvents.OnShowEvent.RemoveListener(OnShow);
        }

        private void OnShow()
        {
            if (firstTimeShowed == false)
            {
                firstTimeShowed = true;
                SlideEvents.OnFirstTimeShowEvent.Invoke();
            }
        }
    }
}