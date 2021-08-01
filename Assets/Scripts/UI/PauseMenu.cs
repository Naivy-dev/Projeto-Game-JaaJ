using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    public GameObject HUD;
    public GameObject pauseHUD;
    public bool isPaused;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }
    private void Pause()
    {
        HUD.SetActive(false);
        pauseHUD.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
    }
    private void UnPause()
    {
        HUD.SetActive(true);
        pauseHUD.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
}
