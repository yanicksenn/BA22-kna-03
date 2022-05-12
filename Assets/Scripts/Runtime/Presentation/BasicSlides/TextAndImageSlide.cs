using Runtime.Tutorial;
using UnityEngine;

namespace Runtime.Presentation.BasicSlides
{
    [CreateAssetMenu(fileName = "TextAndImageSlide", menuName = "BA22/Slide/Create new text and image slide")]
    public class TextAndImageSlide : AbstractSlide, ITextAndImageSlide
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