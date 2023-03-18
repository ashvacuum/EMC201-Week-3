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

    public float _lazerBeamRange = 2f;
    
    private Rigidbody2D _rb;
    private Animator _anim;

    private bool _isOnGround;

    private bool _hasFireballs;

    private bool _hasDoubleJump;

    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speed * 3;
        }
        var Xinput = Input.GetAxis("Horizontal");
        var yinput = Input.GetAxis("Vertical");
        
        transform.Translate( Speed * Time.deltaTime * Xinput,Speed * Time.deltaTime * yinput, transform.position.z);
        

        if (Input.GetButton("Jump") && _isOnGround || _hasDoubleJump)
        {
            if(_isOnGround)
            {
                _hasDoubleJump = true;
            }
            _isOnGround = false;
            Debug.Log("Test Jump");
            _rb.AddForce(Vector2.up * jumpForce);
            StartCoroutine(JumpTimer());
            if (_hasDoubleJump && !_isOnGround)
                _hasDoubleJump = false;
        }


        var walkInput = Input.GetAxis("Horizontal");
        
        _anim.SetBool("isWalking", walkInput != 0);
        _rb.AddForce(Vector2.right * Speed * walkInput);

        if (Input.GetButton("Fire1") && _hasFireballs)
        {
            Instantiate(bulletPrefab, new Vector3(this.transform.position.x + 1,this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }

        if (Input.GetButton("Fire2"))
        {
            LazerBeam();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Platform":
                _isOnGround = true;
                _hasDoubleJump = false;
                break;
            case "Death":
                Debug.Log("You have died");
                SceneManager.LoadScene(1, LoadSceneMode.Single);                
                StopCoroutine(JumpTimer());
                break;
            case "Fireball":
                _hasFireballs = true;
                break;
            default:
                break;
        }
    }

    private IEnumerator JumpTimer()
    {
        yield return new WaitUntil(() => _isOnGround);
        Debug.Log("You have landed");
    }

    public void PeakJump()
    {
                
    }

    public void LazerBeam()
    {
        
        Debug.DrawRay(this.transform.position, Vector2.right * _lazerBeamRange, Color.red, 1f);
        
        var rays =  Physics2D.RaycastAll(this.transform.position, Vector2.right, _lazerBeamRange);

        foreach (var ray in rays)
        {
            if (ray.collider == null) continue;
            if (ray.collider.gameObject.CompareTag("Enemy"))
            {
                Destroy(ray.collider.gameObject);
            }    
        }
        
        
        
    }
}

