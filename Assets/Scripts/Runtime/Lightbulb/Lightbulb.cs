using UnityEngine;
using UnityEngine.Events;

public class Lightbulb : MonoBehaviour
{
    private const string TriggerName = "LightBulbTrigger";
    private static readonly int LightBulbTrigger = Animator.StringToHash(TriggerName);

    private Animator _lightbulbAnimator;
    private bool _isOn;
    public bool IsOn => _isOn;

    [SerializeField] private UnityEvent onLightBulbOn = new UnityEvent();
    [SerializeField] private UnityEvent onLightBulbOff = new UnityEvent();
    private void Awake()
    {
        _lightbulbAnimator = GetComponent<Animator>();
    }

    public void Toggle()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
        _isOn = !_isOn;
        
        if(_isOn)
            onLightBulbOn.Invoke();
        
        else onLightBulbOff.Invoke();
    }
    
    
}