using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D rigid;
    Animator anim;

    //Movement Speed
    [Header("")]
    public float moveSpeed;

    [HideInInspector]
    public static bool canMove = true;
    float x;
    float y;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Get Input Values
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        MovementAnim();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (canMove)
        {
            //Create Direction
            Vector2 move = Vector2.right * x + Vector2.up * y;

            //Normalize 
            move.Normalize();

            //Set Direction and Speed
            rigid.velocity = move * moveSpeed;
        }
        else
            rigid.velocity = Vector2.zero;

    }

    public void MovementAnim()
    {
        // Set Input Values
        if(x != 0 || y != 0)
        {
            anim.SetFloat("xMove", x);
            anim.SetFloat("yMove", y);
        }

        //Check if Velocity is Zero or not
        anim.SetBool("Moving", rigid.velocity != Vector2.zero);
    }
}
