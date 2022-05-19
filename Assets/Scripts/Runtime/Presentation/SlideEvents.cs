using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Presentation
{
    [Serializable]
    public class SlideEvents
    {
        [SerializeField]
        private UnityEvent onShowEvent = new UnityEvent();
        public UnityEvent OnShowEvent => onShowEvent;
        
        [SerializeField]
        private UnityEvent onHideEvent = new UnityEvent();
        public UnityEvent OnHideEvent => onHideEvent;

        [SerializeField] private UnityEvent onFirstTimeShowEvent = new UnityEvent();
        public UnityEvent OnFirstTimeShowEvent => onFirstTimeShowEvent;
    }
}