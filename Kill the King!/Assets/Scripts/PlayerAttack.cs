using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private Animator animator;
    private SpriteRenderer spriterenderer;
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
        move = GetComponent<Move>();
    }
    void Update()
    {

        UseAbility();
        HandleInput();
    }

   public void UseAbility()
    {
        if (timeBtwAttack <= 0)
        {
            //the general action button
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //if there is one
                if (GlobalControl.Instance.itemQueue.Count > 0)
                {

                    //attack
                    if (GlobalControl.Instance.itemQueue[0] == GlobalControl.Actions.Attack)
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
                        GlobalControl.Instance.itemQueue.RemoveAt(0);
                        return;
                    }

                    //jump
                    if (GlobalControl.Instance.itemQueue[0] == GlobalControl.Actions.Jump && move.isGrounded == true && !move.isJumping)
                    {
                        move.takeOffLand = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, move.jumpHeight), ForceMode2D.Impulse);
                        move.isJumping = true;
                        animator.SetBool("isJumping", true);
                        GlobalControl.Instance.itemQueue.RemoveAt(0);
                        return;
                    }
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GlobalControl.Instance.AddAttack();
            Debug.Log("Added attack");

            for (int i = 0; i < GlobalControl.Instance.itemQueue.Count; i++)
            {

                Debug.Log(GlobalControl.Instance.itemQueue[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            GlobalControl.Instance.AddJump();
            Debug.Log("Added Jump");
            for (int i = 0; i < GlobalControl.Instance.itemQueue.Count; i++)
            {
                Debug.Log(GlobalControl.Instance.itemQueue[i]);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
