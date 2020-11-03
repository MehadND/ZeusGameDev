using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //This gets the current scene and goes to the next available scene
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        UnityEngine.Debug.Log("Quit"); //To see if the quit worked
        Application.Quit(); //This closes the game
    }
}
