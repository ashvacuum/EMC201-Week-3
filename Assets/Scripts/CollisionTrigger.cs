using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Enter Collision");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Exit Collision");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Stay Collision");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered Trigger");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Stay Trigger");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit trigger");
    }
}
