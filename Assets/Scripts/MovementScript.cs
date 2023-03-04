using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public void MoveYAxis(float speed)
    {
        transform.Translate(Vector3.up * speed);
        
        //transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }

    public void RotateXAxis(float rotSpeed)
    {
        transform.Rotate(new Vector3(0,0,rotSpeed));
    }
}
