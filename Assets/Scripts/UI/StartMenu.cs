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

    public void SetSense(float sense)
    {
        GameObject camera = GameObject.Find("Main Camera");
        MouseLook mouseLook = camera.GetComponent<MouseLook>();
        mouseLook.mouseSensitivity = sense;
    }


    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
