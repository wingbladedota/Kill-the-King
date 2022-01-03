using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScriptChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GlobalControl");
        if(go == null)
        {
            Debug.LogError("Failed to find object named GlobalControl");
            this.enabled = false;
            return;
        }

        GlobalControl gc = go.GetComponent<GlobalControl>();

    }
}
