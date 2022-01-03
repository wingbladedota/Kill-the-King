using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{
    // public static ShopControl ShopInstance;
    public static ShopControl ShopInstance;

    int level;
    // Start is called before the first frame update
    void Start()
    {
        if (ShopInstance == null)
        {
            Debug.Log("test12");
            Debug.Log("test22");
            ShopInstance = this;
        }
        else if (ShopInstance != this)
        {
            Debug.Log("DELETESC");

            Destroy(gameObject);
        }
    }
    /*  void Awake()
      {
          if (ShopInstance == null)
          {
              DontDestroyOnLoad(gameObject);
              ShopInstance = this;
          }
          else if (ShopInstance != this)
          {
              Destroy(gameObject);
          }
      }*/

    public void SetGold(int level)
    {
        GlobalControl.Instance.startingGold = level;
    }
}
