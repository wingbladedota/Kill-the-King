using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    int currentlevel;
    public void StartLevel()
    {
        SceneManager.LoadScene(currentlevel+1);
    }
    public void SelectLevel(int level)
    {
        currentlevel = level;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
