using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{ 
   private Animator animator;
private SpriteRenderer spriterenderer;
private bool isWalking;
private bool isTalking;
public float moveSpeed;
    public GameObject continueButton;
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
{
    animator = GetComponent<Animator>();
    spriterenderer = GetComponent<SpriteRenderer>();
    moveSpeed = 10f;
}

// Update is called once per frame
void Update()
{
        if (Input.GetButtonDown("Jump"))
        {
            isTalking = false;
        }
        if (!isTalking)
        {
            continueButton.SetActive(false);
            textBox.SetActive(false);

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            transform.position += movement * Time.deltaTime * moveSpeed;

           /* if (movement.x < 0)
            {
                spriterenderer.flipX = true;
            }
            else if (movement.x > 0)
            {
                spriterenderer.flipX = false;

            }*/

            /*if (Input.GetButton("Horizontal"))
            {
                animator.SetBool("isWalking", true);

            }
            else
            {
                animator.SetBool("isWalking", false);
            }*/
        }
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "NPC")
        {
            isTalking = true; continueButton.SetActive(true);
            textBox.SetActive(true);

            Debug.Log("collision");        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "NPC")
        {
            Debug.Log("collisionleave");
        }

    }

}


