using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //gold
    private int attackPrice = 1;
    private int jumpPrice = 1;
    public int startingGold;
    public int currentGold;
    void Awake()
    {
        Debug.Log("test1");
        DontDestroyOnLoad(gameObject);
        Debug.Log("test2");
        if (Instance == null)
         {
             //DontDestroyOnLoad(gameObject);
             Instance = this;
             ResetGold();    
 }
         else if (Instance != this)
         {
             Destroy(gameObject);
         }

        ResetGold();
        SceneManager.LoadScene("MainMenu");

    }


    //The action logic

    public enum Actions
    {
        Jump, Attack
    }
    public List<Actions> itemQueue = new List<Actions>();

    public void ResetActions()
    {
        itemQueue.Clear();
    }


    public void AddJump()
    {
        if (currentGold > 0)
        {
            itemQueue.Add(Actions.Jump);
            currentGold -= jumpPrice;
        }
    }
    public void AddAttack()
    {
        if (currentGold > 0)
        {
            itemQueue.Add(Actions.Attack);
            currentGold -= attackPrice;
        }
    }

    // gold
    public void SetStartingGold(int amount)
    {
        startingGold = amount;
        currentGold = startingGold;
        Debug.Log("SSG");
    }

    public void ResetGold()
    {
        currentGold = startingGold;
    }
}
