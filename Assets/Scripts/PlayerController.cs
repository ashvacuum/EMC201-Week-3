using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float jumpForce = 10f;

    public GameObject bulletPrefab;
    
    private Rigidbody2D _rb;
    private Animator _anim;

    private bool _isOnGround;
    
    
    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Jump") && _isOnGround)
        {
            _isOnGround = false;
            Debug.Log("Test Jump");
            _rb.AddForce(Vector2.up * jumpForce);
        }


        var walkInput = Input.GetAxis("Horizontal");
        
        _anim.SetBool("isWalking", walkInput != 0);
        _rb.AddForce(Vector2.right * Speed * walkInput);

        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, new Vector3(this.transform.position.x + 1,this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Platform":
                _isOnGround = true;
                break;
            case "Death":
                Debug.Log("You have died");
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                
                
                break;
            default:
                break;
        }

        
    }
}
