using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test1");
        DontDestroyOnLoad(gameObject);
        Debug.Log("test2");

    }

}
