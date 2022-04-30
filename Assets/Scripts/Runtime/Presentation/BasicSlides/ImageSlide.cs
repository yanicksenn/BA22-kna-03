using UnityEngine;

namespace Runtime.Presentation.BasicSlides
{
    [CreateAssetMenu(fileName = "ImageSlide", menuName = "BA22/Slide/Create new image slide")]
    public class ImageSlide : AbstractSlide
    {
        [SerializeField, Space]
        private Sprite image;
        public Sprite Image
        {
            get => image;
            set => image = value;
        }
    }
}