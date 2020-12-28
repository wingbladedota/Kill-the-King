using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private Animator animator;
    private SpriteRenderer spriterenderer;
    private ItemQueue itemQueue;
    private Move move;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsHositile;
    public float attackRange;
    public float damage;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        itemQueue = GetComponent<ItemQueue>();
        move = GetComponent<Move>();
    }
    void Update()
    {

        if (timeBtwAttack <= 0)
        {
            //the general action button
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //if there is one
                if (itemQueue.itemQueue.Count > 0){

                    //attack
                    if (GetComponent<ItemQueue>().itemQueue[0] == ItemQueue.Actions.Attack)
                    {
                        Debug.Log("attack used!");
                        animator.SetTrigger("playerAttack");
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsHositile);
                        timeBtwAttack = startTimeBtwAttack;
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<EnemyMovement>().health -= damage;
                            enemiesToDamage[i].GetComponent<KingMovement>().health -= damage;
                        }
                        itemQueue.itemQueue.RemoveAt(0);
                        return;
                    }

                    //jump
                    if (GetComponent<ItemQueue>().itemQueue[0] == ItemQueue.Actions.Jump && move.isGrounded == true && !move.isJumping)
                    {
                        move.takeOffLand = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, move.jumpHeight), ForceMode2D.Impulse);
                        move.isJumping = true;
                        animator.SetBool("isJumping", true);
                        itemQueue.itemQueue.RemoveAt(0);
                        return;
                    }
                }
            } 
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<ItemQueue>().AddAttack();
            Debug.Log("Added attack");

            for (int i = 0; i < GetComponent<ItemQueue>().itemQueue.Count; i++)
            {

                Debug.Log(GetComponent<ItemQueue>().itemQueue[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            GetComponent<ItemQueue>().AddJump();
            Debug.Log("Added Jump");
            for (int i = 0; i < GetComponent<ItemQueue>().itemQueue.Count; i++)
            {
                Debug.Log(GetComponent<ItemQueue>().itemQueue[i]);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
