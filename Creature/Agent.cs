using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : MonoBehaviour
{
    //private AgentAnimations agentAnimations;
    private AgentMover agentMover;
    private WeaponHolder weaponHolder;
    private CrossHairFollowingMouse crossHairFollowingMouse;

    private Vector2 pointerInput, movementInput;
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Awake()
    { 
        //agentAnimations = GetComponentInChildren<AgentAnimations>();
        agentMover = GetComponent<AgentMover>();
        weaponHolder = GetComponentInChildren<WeaponHolder>();
        crossHairFollowingMouse = GetComponentInChildren<CrossHairFollowingMouse>();
    }

    private void Update()
    {
        //pointerInput = GetPointerInput();
        //movementInput = movement.action.ReadValue<Vector2>().normalized;
        
        crossHairFollowingMouse.PointerPosition = pointerInput;
        weaponHolder.PointerPosition = pointerInput;
        agentMover.MovementInput = MovementInput;
    }

    public void PerformAttack()
    {
        weaponHolder.Attack();
    }
}