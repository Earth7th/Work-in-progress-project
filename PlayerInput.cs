using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Animator animator;
    public Vector2 MovementInput { get; set; }
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;
    
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    private void Update()
    {
        OnMovementInput?.Invoke(movement.action.ReadValue<Vector2>().normalized);
        OnPointerInput?.Invoke(GetPointerInput());
        AniP();

    }
    
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }
    
    private void AniP(){ 
        MovementInput = movement.action.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", MovementInput.x);
        animator.SetFloat("Vertical", MovementInput.y);
        animator.SetFloat("Magnitude", MovementInput.magnitude);
    }

}










