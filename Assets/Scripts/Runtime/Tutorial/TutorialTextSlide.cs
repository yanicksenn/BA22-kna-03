using Runtime.Presentation.BasicSlides;
using UnityEngine;

namespace Runtime.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialTextSlide", menuName = "BA22/Slide/Create new Tutorial text slide")]
    public class TutorialTextSlide : AbstractTutorialSlide, ITextSlide
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