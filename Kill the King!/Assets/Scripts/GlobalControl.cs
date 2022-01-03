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
    public static int startingGold;
    public static int currentGold;
    void Start()
    {

      /*  if (Instance == null)
        {
            Debug.Log("test1");
            DontDestroyOnLoad(gameObject);
            Debug.Log("test2");
            //DontDestroyOnLoad(gameObject);
            Instance = this;
             ResetGold();
            SceneManager.LoadScene("MainMenu");

        }
        else if (Instance != this)
        {
            Debug.Log("DELETEGC");

            Destroy(gameObject);
         }
      */
        ResetGold();

    }

    /*void OnDestroy()
    {
        PlayerPrefs.SetInt("startingGold", startingGold);
    }*/
    //The action logic

    public enum Actions
    {
        Jump, Attack
    }
    public static List<Actions> itemQueue = new List<Actions>();

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
        Debug.Log("SetStartingGold, currentgold is "+currentGold);
    }

    public void ResetGold()
    {
        Debug.Log("reset gold " + PlayerPrefs.GetInt("startingGold"));
        currentGold = PlayerPrefs.GetInt("startingGold");
    }
}
