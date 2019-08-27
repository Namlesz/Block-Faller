using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController Mp3;
    public AudioClip firstMusic;
    public AudioClip secondMusic;
    private AudioSource audios;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Mp3 == null)
        {
            Mp3 = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audios = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetString("Music") == "First")
                audios.clip = firstMusic;
            else if (PlayerPrefs.GetString("Music") == "Second")
                audios.clip = secondMusic;
            else
                Debug.LogError("Wrong music key!");

            audios.Play();
        }
        else
        {
            SetFirstAudio();
        }
    }
    public void SetFirstAudio()
    {
        PlayerPrefs.SetString("Music", "First");
        audios.Stop();
        audios.clip = firstMusic;
        audios.Play();
    }

    public void SetSecondAudio()
    {
        PlayerPrefs.SetString("Music", "Second");
        audios.Stop();
        audios.clip = secondMusic;
        audios.Play();
    }
}
