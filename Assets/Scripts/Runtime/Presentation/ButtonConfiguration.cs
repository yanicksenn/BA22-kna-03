using System;
using UnityEngine;

namespace Runtime.Presentation
{
    [Serializable]
    public class ButtonConfiguration
    {
        [SerializeField]
        private string labelText;
        public string LabelText
        {
            get => labelText;
            set => labelText = value;
        }
        
        [SerializeField]
        private bool prohibitsManualNavigation;
        public bool ProhibitsManualNavigation
        {
            get => prohibitsManualNavigation;
            set => prohibitsManualNavigation = value;
        }

        public ButtonConfiguration(string labelText = null, bool prohibitsManualNavigation = false)
        {
            LabelText = labelText;
            ProhibitsManualNavigation = prohibitsManualNavigation;
        }
    }
}