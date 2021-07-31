using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollider : MonoBehaviour
{
    public CharacterController Player;
    [SerializeField] float vol;
    [SerializeField] string audioName;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            FindObjectOfType<AudioManager>().ChangeVolume(audioName , vol);
            Object.Destroy(gameObject);
        }
            
    }

    private void OnTriggerExit(Collider col)
    {
        
    }
}
