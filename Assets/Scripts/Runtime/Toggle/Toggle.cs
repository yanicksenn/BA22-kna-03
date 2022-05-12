using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Toggle : MonoBehaviour
{
    private static readonly int TurnTo1 = Animator.StringToHash("TurnTo1");
    private static readonly int TurnTo0 = Animator.StringToHash("TurnTo0");
    
    private Animator _toggleAnimator;
    private bool isAnimationPlaying;
    private bool toggleOn;
    public bool ToggleOn => toggleOn;

    [SerializeField] private float cooldownPeriod = 1.0f;
   
    [SerializeField] private UnityEvent onToggleOn = new UnityEvent(); 
    public UnityEvent OnToggleOn => onToggleOn;

    [SerializeField] private UnityEvent onToggleOff = new UnityEvent();
    public UnityEvent OnToggleOff => onToggleOff;

    private void Awake()
    {
        _toggleAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isAnimationPlaying)
            StartCoroutine(ToggleAnimation());
    }

    private IEnumerator ToggleAnimation()
    {
        isAnimationPlaying = true;
        _toggleAnimator.SetTrigger(toggleOn ? TurnTo0 : TurnTo1);
        var animationLength = _toggleAnimator.GetCurrentAnimatorStateInfo(0).length;
        
        // Wait until animation is finished to invoked the events
        yield return new WaitForSeconds(animationLength);
        
        toggleOn = !toggleOn;
        if(toggleOn)
            OnToggleOn.Invoke();
        else
            OnToggleOff.Invoke();

        // Wait the for the cooldown period after invoking the events
        yield return new WaitForSeconds(cooldownPeriod);
        isAnimationPlaying = false;
    }
    
}
