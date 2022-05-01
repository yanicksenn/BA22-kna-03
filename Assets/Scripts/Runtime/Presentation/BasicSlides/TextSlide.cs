using UnityEngine;

namespace Runtime.Presentation.BasicSlides
{
    [CreateAssetMenu(fileName = "TextSlide", menuName = "BA22/Slide/Create new text slide")]
    public class TextSlide : AbstractSlide, ITextSlide
    {
        [SerializeField, Space]
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }

        public string GetText()
        {
            return text;
        }
    }
}