using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private Animator _buttonAnimator;

    private void Start()
    {
        _buttonAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _buttonAnimator.SetTrigger("ButtonPressed");
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
