using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject loadingInterface;
    public float mSense, vol;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void LoadGame()
    {
        startMenu.SetActive(false);
        loadingInterface.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TUTORIAL_1));
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        for(int i=0; i<scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                yield return null;
            }
        }
    }

    //Sensitivity and Volume Slider

    private void Start()
    {
        SetSense(1f);
    }

    public void SetSense(float sense)
    {
        //GameObject camera = GameObject.Find("Main Camera");
        //MouseLook mouseLook = camera.GetComponent<MouseLook>();
        this.mSense = sense;
    }


    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        this.vol = volume;   
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
