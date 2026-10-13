using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Movement variables
    public float moveSpeed;
    public float jumpHeight;

    // Keyboard controls
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim= GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        // Move Left
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip character to face left
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Move Right
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip character to face right
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

         anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
         anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
         anim.SetBool("Grounded", grounded);
    }

    // Jump function
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(
                GetComponent<Rigidbody2D>().velocity.x,
                jumpHeight
            );
    }

    // Check if player is touching the ground
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            whatIsGround
        );
    }
}