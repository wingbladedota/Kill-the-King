using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{
    int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetGold(int level)
    {
        GlobalControl.Instance.startingGold = level;
    }
}
