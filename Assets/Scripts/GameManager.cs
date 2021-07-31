using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    public void StartGame()
    {
        
        SceneManager.LoadSceneAsync((int)SceneIndexes.TUTORIAL_1);
    }
}
