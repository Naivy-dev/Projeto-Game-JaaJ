using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene((int)SceneIndexes.TUTORIAL_1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
