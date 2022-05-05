using Runtime.Tutorial;
using UnityEngine;

namespace Runtime.Presentation.BasicSlides
{
    [CreateAssetMenu(fileName = "TextAndImageSlide", menuName = "BA22/Slide/Create new text and image slide")]
    public class TextAndImageSlide : AbstractSlide, ITextAndImageSlide
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