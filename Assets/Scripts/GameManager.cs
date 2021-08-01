using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StartMenu menu;
    public float mouseSense, vol;
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

    private void Update()
    {
        if(menu == null)
        {
            return;
        }
        mouseSense = menu.mSense;
        vol = menu.vol;
    }
}
