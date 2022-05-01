using Runtime.Presentation.BasicSlides;
using UnityEngine;

namespace Runtime.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialTextAndImageSlide", menuName = "BA22/Slide/Create new Tutorial text and image slide")]
    public class TutorialTextAndImageSlide : AbstractTutorialSlide, ITextAndImageSlide
    {
        [SerializeField, Space]
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }
        
        [SerializeField, Space]
        private Sprite image;
        public Sprite Image
        {
            get => image;
            set => image = value;
        }

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