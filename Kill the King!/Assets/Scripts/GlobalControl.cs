using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            ResetGold();
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

    public void Reset()
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
    private int attackPrice=1;
    private int jumpPrice = 1;
    private int startingGold=5;
    public int currentGold;

    public void ResetGold()
    {
        currentGold = startingGold;
    }
}
