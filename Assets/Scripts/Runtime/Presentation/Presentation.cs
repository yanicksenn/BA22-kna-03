using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Presentation
{
    [CreateAssetMenu(fileName = "Presentation", menuName = "BA22/Create new presentation")]
    public class Presentation : ScriptableObject
    {
        [SerializeField]
        private List<AbstractSlide> slides = new List<AbstractSlide>();
        public List<AbstractSlide> Slides
        {
            get => slides;
            set => slides = value;
        }
    }
}