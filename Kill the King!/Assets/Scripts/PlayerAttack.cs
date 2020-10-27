using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private Animator animator;
    private SpriteRenderer spriterenderer;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsHositile;
    public float attackRange;
    public float damage;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("attack used!");
                animator.SetTrigger("playerAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange, whatIsHositile);
                timeBtwAttack = startTimeBtwAttack;
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyMovement>().health -= damage;
                    enemiesToDamage[i].GetComponent<KingMovement>().health -= damage;
                }
            } 
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
