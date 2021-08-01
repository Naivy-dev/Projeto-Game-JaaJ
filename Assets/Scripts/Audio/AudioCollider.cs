using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollider : MonoBehaviour
{
    public Sound[] sounds;
    public int cont;
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
            if(cont < sounds.Length)
            {
                newTrack = sounds[cont].clip;
                AudioManager.instance.AddTrack(newTrack);
                cont++;
            }
        }

    }
}