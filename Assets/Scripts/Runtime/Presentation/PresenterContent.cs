using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Presentation
{
    [CreateAssetMenu(fileName = "PresenterContent", menuName = "BA22/Create new presenter content")]
    public class PresenterContent : ScriptableObject
    {
        [SerializeField] private Presentation currentPresentation;
        [SerializeField] private UnityEvent onPresentationChanged = new UnityEvent();
        public UnityEvent OnPresentationChanged => onPresentationChanged;

        public Presentation CurrentPresentation => currentPresentation;

        public void SetCurrentPresentation(Presentation nextPresentation)
        {
            if (nextPresentation == currentPresentation)
                return;
            
            currentPresentation = nextPresentation;
            OnPresentationChanged.Invoke();
        }
    }
}