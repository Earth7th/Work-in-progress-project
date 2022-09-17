using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimetorEventHelper : MonoBehaviour
{
    public UnityEvent OnAnimationEvenTriggered, OnAttackPeformed;

    public void TriggerAttack()
    {
        OnAttackPeformed.Invoke();
    }
}
