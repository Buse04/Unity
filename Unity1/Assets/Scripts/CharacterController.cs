using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D r2d;
    Animator _animator;
    [SerializeField] GameObject _cam;
    Vector3 charPos;
    SpriteRenderer sprt;


    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        sprt = GetComponent<SpriteRenderer>();
        
    }

    void FixedUpdate()
    {
        r2d.velocity = new Vector2(speed, 0.0f);
    }

    void Update()
    {
        charPos = new Vector3(charPos.x + (speed * Time.deltaTime * Input.GetAxis("Horizontal")), charPos.y);
        transform.position = charPos;
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            sprt.flipX = false;
        }

        else if(Input.GetAxis("Horizontal") < 0.01f)
        {
            sprt.flipX = true;
        }
    }

    void LateUpdate()
    {
        _cam.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}



