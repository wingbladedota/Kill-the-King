using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{
   // public static ShopControl ShopInstance;

    int level;
    // Start is called before the first frame update
    void Start()
    {

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
