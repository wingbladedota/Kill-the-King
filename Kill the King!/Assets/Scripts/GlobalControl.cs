using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //gold
    private int attackPrice = 1;
    private int jumpPrice = 1;
    public int startingGold = 5;
    public int currentGold;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            ResetGold();    
             attackPrice = 1;
    jumpPrice = 1;
     startingGold = 5;
}
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
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


    public void ResetGold()
    {
        currentGold = startingGold;
    }
}
