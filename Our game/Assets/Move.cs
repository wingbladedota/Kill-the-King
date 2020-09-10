using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{ 
   private Animator animator;
private SpriteRenderer spriterenderer;
private bool isWalking;
public bool isTalking;
public float moveSpeed;
    public GameObject textBox;
    public DialogueTrigger dialoguetrigger;
    public GameObject nameText;
    public GameObject dialogueText;
    public DialogueManager dialoguemanager;

    // Start is called before the first frame update
    void Start()
{
    animator = GetComponent<Animator>();
    spriterenderer = GetComponent<SpriteRenderer>();
    moveSpeed = 10f;
        textBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
{
        if (Input.GetButtonDown("Jump"))
        {
            isTalking = false;
            textBox.SetActive(false);
            nameText.SetActive(false);
            dialogueText.SetActive(false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            //dialoguetrigger.dialogue.DisplayNextSentence();
        }
        if (isTalking && Input.GetButtonDown("Fire1"))
        {
            dialoguemanager.DisplayNextSentence();
        }
        if (!isTalking)
        {


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
        if (collision.collider.tag == "NPC")
        {
            textBox.SetActive(true); 
            nameText.SetActive(true);
            dialogueText.SetActive(true);
        }
    }

    
}


