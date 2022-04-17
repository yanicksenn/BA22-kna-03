using System;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    private const string TriggerName = "ButtonPressed";
    private static readonly int ButtonPressed = Animator.StringToHash(TriggerName);
    
    private Animator _switchAnimator;
    private bool switchOn;
    public bool SwitchOn => switchOn;
    
    [SerializeField] private UnityEvent onSwitchOn = new UnityEvent(); 
    public UnityEvent OnSwitchOn => onSwitchOn;

    [SerializeField] private UnityEvent onSwitchOff = new UnityEvent();
   
    public UnityEvent OnSwitchOff => onSwitchOff;

    private void Awake()
    {
        _switchAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _switchAnimator.SetTrigger(ButtonPressed);
        switchOn = !switchOn;
        if(switchOn)
            OnSwitchOn.Invoke();
        else
            OnSwitchOff.Invoke();
    }
    
}
