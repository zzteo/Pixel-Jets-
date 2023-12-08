using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
