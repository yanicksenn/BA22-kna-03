using Runtime.Presentation.BasicSlides;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialImageSlide", menuName = "BA22/Slide/Create new Tutorial image slide")]
    public class TutorialImageSlide : AbstractTutorialSlide, IImageSlide
    {
        [SerializeField, Space]
        private Sprite image;
        public Sprite Image
        {
            get => image;
            set => image = value;
        }

        public Sprite GetImage()
        {
            return image;
        }
    }
}