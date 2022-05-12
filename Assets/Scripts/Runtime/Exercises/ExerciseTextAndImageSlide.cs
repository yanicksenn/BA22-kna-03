using Runtime.Presentation;
using Runtime.Presentation.BasicSlides;
using UnityEngine;

namespace Runtime.Exercises
{
    [CreateAssetMenu(fileName = "ExerciseTextAndImageSlide", menuName = "BA22/Slide/Create new exercise text and image slide")]
    public class ExerciseTextAndImageSlide : AbstractExerciseSlide, ITextAndImageSlide
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