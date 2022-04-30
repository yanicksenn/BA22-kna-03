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
        private Image imageSection;
        public Image ImageSection
        {
            get => imageSection;
            set => imageSection = value;
        }

        [SerializeField]
        private TMP_Text textSection;
        public TMP_Text TextSection
        {
            get => textSection;
            set => textSection = value;
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

        private void Awake()
        {
            Reset();
        }

        private void Update()
        {
            var currentSlide = GetCurrentSlide();
            if (currentSlide == null)
                return;

            textSection.gameObject.SetActive(false);
            imageSection.gameObject.SetActive(false);

            headerLabel.text = currentSlide.Title;
            
            nextButton.gameObject.SetActive(currentSlide.AllowsNext && HasNext());
            nextButtonLabel.text = currentSlide.NextButtonName;
                
            previousButton.gameObject.SetActive(currentSlide.AllowsPrevious && HasPrevious());
            previousButtonLabel.text = currentSlide.PreviousButtonName;
            
            switch (currentSlide)
            {
                case TextSlide textSlide:
                    ShowTextSlide(textSlide);
                    break;
                
                case ImageSlide imageSlide:
                    ShowImageSlide(imageSlide);
                    break;
            }
        }

        private void ShowTextSlide(TextSlide textSlide)
        {
            textSection.gameObject.SetActive(true);
            textSection.text = textSlide.Text;
        }

        private void ShowImageSlide(ImageSlide imageSlide)
        {
            imageSection.gameObject.SetActive(true);
            imageSection.sprite = imageSlide.Image;
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
            foreach (var navigationCondition in NavigationConditions)
                navigationCondition.OnShowSlide(GetCurrentSlide());
        }

        private void FireHideSlideEvent()
        {
            foreach (var navigationCondition in NavigationConditions)
                navigationCondition.OnHideSlide(GetCurrentSlide());
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