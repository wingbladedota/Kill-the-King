using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriterenderer;
    public bool isWalking;
    public bool isJumping;
    public bool takeOffLand;
    public bool isGrounded;
    public float moveSpeed ;
    public float jumpHeight ;
    public bool facingRight;
    public GameObject AttackPos;
    public float attackPosX;

    Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

// Update is called once per frame
void Update()
    {
        if (takeOffLand)
        {
            takeOffLand = false;
        }
        //Jump();
       
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x>0)
        {
             transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("isWalking", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
            isWalking = false;
        }
        if (!isJumping)
        {
            animator.SetBool("isJumping", false);
        }
        if (takeOffLand)
        {
            //animator.SetBool("takeOffLand", true);

        }
        else
        {
            //animator.SetBool("takeOffLand", false);
        }
    }

   /* void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded==true)
        {
            //takeOffLand = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }*/
}
