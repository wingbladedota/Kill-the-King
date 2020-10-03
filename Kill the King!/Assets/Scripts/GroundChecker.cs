using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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
