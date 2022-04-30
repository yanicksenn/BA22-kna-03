using UnityEngine;

namespace Runtime.Presentation
{
    public abstract class AbstractSlide : ScriptableObject
    {
        [SerializeField] private string title;

        public string Title
        {
            get => title;
            set => title = value;
        }

        [SerializeField, Space] private string nextButtonName = "Next";

        public string NextButtonName
        {
            get => nextButtonName;
            set => nextButtonName = value;
        }

        [SerializeField] private bool allowsNext = true;

        public bool AllowsNext
        {
            get => allowsNext;
            set => allowsNext = value;
        }

        [SerializeField, Space] private string previousButtonName = "Previous";

        public string PreviousButtonName
        {
            get => previousButtonName;
            set => previousButtonName = value;
        }

        [SerializeField] private bool allowsPrevious = false;

        public bool AllowsPrevious
        {
            get => allowsPrevious;
            set => allowsPrevious = value;
        }
    }
}