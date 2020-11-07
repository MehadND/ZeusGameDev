using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Player.score = 0;
            Player.lives = 3;
        }
        else
        {
            Player.score = 0;
            Player.lives = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
