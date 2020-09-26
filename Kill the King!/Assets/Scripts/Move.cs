using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriterenderer;
    private bool isWalking;
    public bool isJumping;
    public bool takeOffLand;
    public bool isGrounded;
    public float baseMove ;
    public float speedBoost ;
    public float moveSpeed ;
    public float jumpHeight ;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        baseMove = 5f; speedBoost = 5f; moveSpeed = 10f; jumpHeight = 7f;
    }

// Update is called once per frame
void Update()
    {
        if (takeOffLand)
        {
            takeOffLand = false;
        }
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (movement.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else if (movement.x>0)
        {
            spriterenderer.flipX = false;

        }

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("isWalking", true);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (!isJumping)
        {
            animator.SetBool("isJumping", false);
        }
        if (takeOffLand)
        {
            animator.SetBool("takeOffLand", true);

        }
        else
        {
            animator.SetBool("takeOffLand", false);

        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded==true)
        {
            takeOffLand = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }
}
