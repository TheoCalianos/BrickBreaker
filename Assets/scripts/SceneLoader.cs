using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        Scene current = SceneManager.GetActiveScene();
        int newindex = current.buildIndex + 1;
        SceneManager.LoadScene(newindex);
    }
    public void LoadHomeScence()
    {
        SceneManager.LoadScene("Start Menu");
        FindObjectsOfType<GameStatus>()[0].ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}