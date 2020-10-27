using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingMovement : MonoBehaviour
{
    public float health;
    void Start()
    {
        this.health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
            Debug.Log("switch scene");
        }
    }
}
