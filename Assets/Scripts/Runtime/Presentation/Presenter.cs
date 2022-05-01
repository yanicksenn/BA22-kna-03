using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Presentation.BasicSlides;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Presentation
{
    [ExecuteAlways]
    public class Presenter : MonoBehaviour
    {
        [SerializeField]
        private Presentation presentation;
        public Presentation Presentation
        {
            get => presentation;
            set => presentation = value;
        }

        [SerializeField, Space] 
        private TMP_Text headerLabel;
        public TMP_Text HeaderLabel
        {
            get => headerLabel;
            set => headerLabel = value;
        }

        [SerializeField]
        private Image fullImageSection;
        public Image FullImageSection
        {
            get => fullImageSection;
            set => fullImageSection = value;
        }

        [SerializeField]
        private TMP_Text fullTextSection;
        public TMP_Text FullTextSection
        {
            get => fullTextSection;
            set => fullTextSection = value;
        }
        
        [SerializeField]
        private Image halfImageSection;
        public Image HalfImageSection
        {
            get => halfImageSection;
            set => halfImageSection = value;
        }

        [SerializeField]
        private TMP_Text halfTextSection;
        public TMP_Text HalfTextSection
        {
            get => halfTextSection;
            set => halfTextSection = value;
        }
        
        [SerializeField, Space]
        private Button nextButton;
        public Button NextButton
        {
            get => nextButton;
            set => nextButton = value;
        }
        
        [SerializeField]
        private TMP_Text nextButtonLabel;
        public TMP_Text NextButtonLabel
        {
            get => nextButtonLabel;
            set => nextButtonLabel = value;
        }

        [SerializeField, Space]
        private Button previousButton;
        public Button PreviousButton
        {
            get => previousButton;
            set => previousButton = value;
        }
        
        [SerializeField]
        private TMP_Text previousButtonLabel;
        public TMP_Text PreviousButtonLabel
        {
            get => previousButtonLabel;
            set => previousButtonLabel = value;
        }

        private HashSet<INavigationInterceptor> navigationConditions = new HashSet<INavigationInterceptor>();
        public HashSet<INavigationInterceptor> NavigationConditions
        {
            get => navigationConditions;
            set => navigationConditions = value;
        }

        private int _currentSlideIndex;

        private AbstractSlide GetCurrentSlide()
        {
            if (presentation == null)
                return null;

            var currentSlideIndex = GetCurrentSlideIndex();
            if (currentSlideIndex < 0 || currentSlideIndex >= presentation.Slides.Count)
                return null;

            return presentation.Slides[currentSlideIndex];
        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            var currentSlide = GetCurrentSlide();
            if (currentSlide == null)
                return;

            fullTextSection.gameObject.SetActive(false);
            fullImageSection.gameObject.SetActive(false);
            
            halfTextSection.gameObject.SetActive(false);
            halfImageSection.gameObject.SetActive(false);

            headerLabel.text = currentSlide.Title;
            
            nextButton.gameObject.SetActive(IsNextButtonEnabled(currentSlide));
            nextButtonLabel.text = currentSlide.NextButton.LabelText;
                
            previousButton.gameObject.SetActive(IsPreviousButtonEnabled(currentSlide));
            previousButtonLabel.text = currentSlide.PreviousButton.LabelText;
            
            switch (currentSlide)
            {
                case ITextSlide and IImageSlide:
                    ShowTextAndImageSlide((ITextAndImageSlide) currentSlide);
                    break;
                case ITextSlide textSlide:
                    ShowFullTextSlide(textSlide);
                    break;
                case IImageSlide imageSlide:
                    ShowFullImageSlide(imageSlide);
                    break;
            }
            
           
        }

        private bool IsPreviousButtonEnabled(AbstractSlide currentSlide)
        {
            return !currentSlide.PreviousButton.ProhibitsManualNavigation && HasPrevious();
        }

        private bool IsNextButtonEnabled(AbstractSlide currentSlide)
        {
            return !currentSlide.NextButton.ProhibitsManualNavigation && HasNext();
        }

        private void ShowFullTextSlide(ITextSlide textSlide)
        {
            fullTextSection.gameObject.SetActive(true);
            fullTextSection.text = textSlide.GetText();
        }

        private void ShowFullImageSlide(IImageSlide imageSlide)
        {
            fullImageSection.gameObject.SetActive(true);
            fullImageSection.sprite = imageSlide.GetImage();
        }

        private void ShowTextAndImageSlide(ITextAndImageSlide textAndImageSlide)
        {
            halfTextSection.gameObject.SetActive(true);
            halfTextSection.text = textAndImageSlide.GetText();
            
            halfImageSection.gameObject.SetActive(true);
            halfImageSection.sprite = textAndImageSlide.GetImage();
        }

        public void Reset()
        {
            FireHideSlideEvent();
            _currentSlideIndex = 0;
            FireShowSlideEvent();
        }

        public void Next()
        {
            if (presentation == null)
                return;

            if (NavigationConditions.Count > 0 &&
                NavigationConditions.Any(e => e.AllowsNext(GetCurrentSlide())) == false)
                return;
            
            FireHideSlideEvent();
            _currentSlideIndex++;
            FireShowSlideEvent();
        }
        

        public void Previous()
        {
            if (presentation == null)
                return;
            
            FireHideSlideEvent();
            _currentSlideIndex--;
            FireShowSlideEvent();
        }

        private void FireShowSlideEvent()
        {
            var currentSlide = GetCurrentSlide();
            
            if (currentSlide == null)
                return;

            currentSlide.SlideEvents.OnShowEvent.Invoke();

            foreach (var navigationCondition in NavigationConditions)
                navigationCondition.OnShowSlide(currentSlide);
        }

        private void FireHideSlideEvent()
        {
            var currentSlide = GetCurrentSlide();
            
            if (currentSlide == null)
                return;
            
            currentSlide.SlideEvents.OnHideEvent.Invoke();
            
            foreach (var navigationCondition in NavigationConditions)
                navigationCondition.OnHideSlide(currentSlide);
        }

        private int GetCurrentSlideIndex()
        {
            if (Presentation == null)
                return 0;
            
            if (Presentation.Slides.Count == 0)
                return 0;
            
            return Math.Clamp(_currentSlideIndex, 0, presentation.Slides.Count - 1);
        }

        private bool HasPrevious()
        {
            return GetCurrentSlideIndex() > 0;
        }

        private bool HasNext()
        {
            if (presentation == null)
                return false;
            
            return GetCurrentSlideIndex() < presentation.Slides.Count - 1;
        }
        
    }
}