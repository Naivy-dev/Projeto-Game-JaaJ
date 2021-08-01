using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollider : MonoBehaviour
{
    public Sound[] sounds;
    public AudioClip newTrack;
    private void OnTriggerEnter(Collider col)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
        if (col.tag == "Player")
        {
            if(AudioManager.instance.cont < sounds.Length)
            {
                newTrack = sounds[AudioManager.instance.cont].clip;
                AudioManager.instance.AddTrack(newTrack);
                AudioManager.instance.cont++;
            }
        }
        this.gameObject.SetActive(false);
    }
}