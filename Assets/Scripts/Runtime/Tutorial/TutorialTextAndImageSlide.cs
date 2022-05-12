using Runtime.Presentation.BasicSlides;
using UnityEngine;

namespace Runtime.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialTextAndImageSlide", menuName = "BA22/Slide/Create new Tutorial text and image slide")]
    public class TutorialTextAndImageSlide : AbstractTutorialSlide, ITextAndImageSlide
    {
        [SerializeField, Space]
        private string text;
        
        [SerializeField, Space]
        private Sprite image;

        public string GetText()
        {
            return text;
        }
        
        public Sprite GetImage()
        {
            return image;
        }
    }
}