using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 1000f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.AddForce(Vector2.right * _speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Platform":
            case "Player":
            case "Death":
                break;
            default:
                Destroy(col.gameObject);
                break;
        }

    }
}
