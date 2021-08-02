using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    public AudioClip DefaultClip;
    public AudioSource track01, track02, track03, track04, track05;
    public static AudioManager instance;
    public int cont;
    public bool isPlaying01;
    public int isPlayingOthers;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        track03 = gameObject.AddComponent<AudioSource>();
        track04 = gameObject.AddComponent<AudioSource>();
        track05 = gameObject.AddComponent<AudioSource>();
        track01.loop = true;
        track02.loop = true;
        track03.loop = true;
        track04.loop = true;
        track05.loop = true;
        track02.volume = 0;
        track03.volume = 0;
        track04.volume = 0;
        track05.volume = 0;
        AddTrack(DefaultClip);
        isPlaying01 = true;
        isPlayingOthers = 1;
    }

    public void AddTrack(AudioClip newClip)
    {
        StartCoroutine(FadeTrack(newClip));
        isPlayingOthers++;
    }
    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float FadeTime = 1.5f;
        float TimeElapsed = 0;
        if (isPlaying01)
        {
              if (isPlayingOthers == 1)
            {
                track02.clip = newClip;
                track02.PlayDelayed(track01.clip.length - track01.time);
                yield return new WaitForSeconds(track01.clip.length - track01.time);
                while (TimeElapsed < FadeTime)
                {
                    track02.volume = Mathf.Lerp(0, 0.5f, TimeElapsed / FadeTime);
                    yield return new WaitForSeconds(0.001f);
                    TimeElapsed += Time.deltaTime;
                }
            }
            else if (isPlayingOthers == 2)
            {
                track03.clip = newClip;
                track03.PlayDelayed(track02.clip.length - track01.time);
                yield return new WaitForSeconds(track02.clip.length - track01.time);
                while (TimeElapsed < FadeTime)
                {
                    track03.volume = Mathf.Lerp(0, 0.5f, TimeElapsed / FadeTime);
                    yield return new WaitForSeconds(0.001f);
                    TimeElapsed += Time.deltaTime;

                }
            }
            else if (isPlayingOthers == 3)
            {
                track04.clip = newClip;
                track04.PlayDelayed(track03.clip.length - track01.time);
                yield return new WaitForSeconds(track03.clip.length - track01.time);
                while (TimeElapsed < FadeTime)
                {
                    track04.volume = Mathf.Lerp(0, 0.5f, TimeElapsed / FadeTime);
                    yield return new WaitForSeconds(0.001f);
                    TimeElapsed += Time.deltaTime;

                }
            }
            else if (isPlayingOthers == 4)
            {
                track05.clip = newClip;
                track05.PlayDelayed(track04.clip.length - track01.time);
                yield return new WaitForSeconds(track04.clip.length - track01.time);
                while (TimeElapsed < FadeTime)
                {
                    track05.volume = Mathf.Lerp(0, 0.5f, TimeElapsed / FadeTime);
                    yield return new WaitForSeconds(0.001f);
                    TimeElapsed += Time.deltaTime;

                }
            }
        }
        else
        {
            track01.clip = newClip;
            track01.Play();
            while (TimeElapsed < FadeTime)
            {
                track01.volume = Mathf.Lerp(0, 0.5f, TimeElapsed / FadeTime);
                TimeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

}