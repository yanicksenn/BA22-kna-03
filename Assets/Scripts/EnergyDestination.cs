using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDestination : MonoBehaviour
{
    private const string TriggerName = "LightBulbTrigger";
    private static readonly int LightBulbTrigger = Animator.StringToHash(TriggerName);
    
    private Animator _lightbulbAnimator;   
    
    private void Awake()
    {
        _lightbulbAnimator = GetComponent<Animator>();
    }

    public void turnOnLightbulb()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
    }

    public void turnOffLightbulb()
    {
        _lightbulbAnimator.SetTrigger(LightBulbTrigger);
    }
}
