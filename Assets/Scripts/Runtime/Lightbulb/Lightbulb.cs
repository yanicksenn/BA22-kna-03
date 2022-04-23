using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    private const string TriggerName = "LightBulbTrigger";
    private static readonly int LightBulbTrigger = Animator.StringToHash(TriggerName);

    private Animator _lightbulbAnimator;
    private bool _isOn;
    public bool IsOn => _isOn;

    private void Awake()
    {
        _lightbulbAnimator = GetComponent<Animator>();
    }

    public void Toggle()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
        _isOn = !_isOn;
    }
}