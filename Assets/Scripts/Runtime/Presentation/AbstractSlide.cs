using UnityEngine;

namespace Runtime.Presentation
{
    public abstract class AbstractSlide : ScriptableObject
    {
        [SerializeField] 
        private string title;
        public string Title
        {
            get => title;
            set => title = value;
        }

        [SerializeField, Space] 
        private string nextButtonName = "Next";
        public string NextButtonName
        {
            get => nextButtonName;
            set => nextButtonName = value;
        }

        [SerializeField] 
        private bool allowsManualNext = true;
        public bool AllowsNext
        {
            get => allowsManualNext;
            set => allowsManualNext = value;
        }

        [SerializeField, Space]
        private string previousButtonName = "Previous";
        public string PreviousButtonName
        {
            get => previousButtonName;
            set => previousButtonName = value;
        }

        [SerializeField] 
        private bool allowsManualPrevious = false;
        public bool AllowsPrevious
        {
            get => allowsManualPrevious;
            set => allowsManualPrevious = value;
        }
    }
}