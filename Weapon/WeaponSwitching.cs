using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    private InputActionReference mouseScroll;
    private Vector2 mouseScrollInput;
    public float Delay = 1.0f;
    public int selectedWeapon = 0;
    // Start is called before the first frame update

    void Start()
    {
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(MeleeAttackIsPlay.completeAttack == true)
        ChangeWeapon();

    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void ChangeWeapon()
    {
        mouseScrollInput = mouseScroll.action.ReadValue<Vector2>();
            int previousSelectedWeapon = selectedWeapon;

            if (mouseScrollInput.y < 0.0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++; 
            }

            if (mouseScrollInput.y > 0.0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--; 
            }

            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                selectedWeapon = 0;
            }

            if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                selectedWeapon = 1;
            }

            if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                selectedWeapon = 2;
            }

            if (Keyboard.current.digit4Key.wasPressedThisFrame)
            {
                selectedWeapon = 3;
            }

            if (Keyboard.current.digit5Key.wasPressedThisFrame)
            {
                selectedWeapon = 4;
            }

            if (Keyboard.current.digit6Key.wasPressedThisFrame)
            {
                selectedWeapon = 5;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectedWeapon();
            }
    
    }
}
