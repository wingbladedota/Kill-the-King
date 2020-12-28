using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walkable")
        {

            Player.GetComponent<Move>().isGrounded = true;
            Player.GetComponent<Move>().isJumping = false;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walkable")
        {
            Player.GetComponent<Move>().isGrounded = false;
            Console.WriteLine("asd");
        }

    }





}
