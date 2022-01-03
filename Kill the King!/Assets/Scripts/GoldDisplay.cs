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
        GameObject go = GameObject.Find("GlobalObject");
        if (go == null)
        {
            Debug.LogError("Failed to find object named GlobalObject");
            this.enabled = false;
            return;
        }

        GlobalControl gc = go.GetComponent<GlobalControl>();
        GoldCounter.SetText("Gold :  " + gc.currentGold.ToString());
    }
}
