using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCotroller2 : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    float moveDirection;
    bool jump;
    bool grounded = true;
    bool moving;

    Rigidbody2D rdg;
    Animator ani;
    SpriteRenderer sprt;
    [SerializeField] GameObject cam;
    

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        rdg = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (rdg.velocity != Vector2.zero)
        {
            moving = true;
            
        }

        else
        {
            moving = false;
        }
        
        if(jump == true)
        {
            rdg.velocity = new Vector2(rdg.velocity.x, jumpForce);
            jump = false;
            

        }
        rdg.velocity = new Vector2(speed * moveDirection, rdg.velocity.y);

    }
    void Update()
    {
        if ( (Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                sprt.flipX = true;
                ani.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                sprt.flipX = false;
                ani.SetFloat("speed", speed);
            }
            
        }

        else if (grounded == true)
        {
            moveDirection = 0.0f;
            ani.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            
        }
    }

    void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
