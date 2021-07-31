using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            //Debug.Log("oi");
            LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadSceneAsync(gameObject.name);
    }
}
