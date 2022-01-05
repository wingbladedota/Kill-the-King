using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
   // public static GoldDisplay GoldDisplayInstance;

    public TMP_Text GoldCounter;
  /*  void Awake()
    {
        if (GoldDisplayInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            GoldDisplayInstance = this;
        }
        else if (GoldDisplayInstance != this)
        {
            Destroy(gameObject);
        }
    }*/
    public void Update()
    {
        GoldCounter.SetText("Gold :  " + GlobalControl.currentGold.ToString());
    }
}
