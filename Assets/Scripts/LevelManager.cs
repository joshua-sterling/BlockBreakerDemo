using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.bricksRemaining = 0;
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Request to quit the game");
        Application.Quit();
    }

    public void returnToScene(string name)
    {
        SceneManager.LoadScene(name);
       
    }

    public void LoadNextLevel()
    {
        Brick.bricksRemaining = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*Every time a brick is destroyed, see if there are any left*/
    public void BrickDestroyed()
    {
        if(Brick.bricksRemaining <= 0)
        {
            LoadNextLevel();
        }
    }

    

}
