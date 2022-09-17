using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHairFollowingMouse : MonoBehaviour
{
    public Vector2 PointerPosition {get; set;}
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 position = PointerPosition;
        position.z = 1.0f;
        transform.position = position;
    }

}

