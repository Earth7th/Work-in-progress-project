using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    
    public float FollowSpeed = 2.0f;
    public float yOffset = 0.1f;
    public float xOffset = 0.1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
            Vector3 newPos = new Vector3(target.position.x + xOffset,target.position.y + yOffset,-10.0f);
            transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
