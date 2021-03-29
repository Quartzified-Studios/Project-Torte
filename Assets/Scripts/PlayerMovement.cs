using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    //Components
    Rigidbody2D rigid;
    Animator anim;
    public InputMaster controls;

    //Movement Speed
    [Header("")]
    public float moveSpeed;

    public static bool canMove = true;
    Vector2 direction;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controls = new InputMaster();

    }

    private void Start()
    {
        RegisterInputs();
    }

    private void Update()
    {
        MovementAnim();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    void RegisterInputs()
    {
        controls.Player.Movement.performed += ctx => direction = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => direction = Vector2.zero;
    }

    public void Movement()
    {
        if (canMove)
        {
            //Create Direction
            Vector2 move = Vector2.right * direction.x + Vector2.up * direction.y;

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
        if(direction.x != 0 || direction.y != 0)
        {
            anim.SetFloat("xMove", direction.x);
            anim.SetFloat("yMove", direction.y);
        }

        //Check if Velocity is Zero or not
        anim.SetBool("Moving", rigid.velocity != Vector2.zero);
    }
}
