using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    public TMP_Text GoldCounter;

    private void Update()
    {
        GoldCounter.SetText("Gold :  " + GlobalControl.Instance.currentGold.ToString());
    }
}
