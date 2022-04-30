using UnityEngine;

namespace Runtime.Presentation
{
    [CreateAssetMenu(fileName = "TextSlide", menuName = "BA22/Slide/Create new text slide")]
    public class TextSlide : AbstractSlide
    {
        [SerializeField]
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }
    }
}