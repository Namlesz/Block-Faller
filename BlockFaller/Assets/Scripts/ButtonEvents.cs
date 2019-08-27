using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void ChangeMusic()
    {
        MusicController musicController = GameObject.Find("MusicPlayer").GetComponent<MusicController>();

        if (PlayerPrefs.GetString("Music") == "First")
        {
            musicController.SetSecondAudio();
        }
        else
        {
            musicController.SetFirstAudio();
        }
    }

    public void Quit() => Application.Quit();

    private void OnApplicationQuit() => PlayerPrefs.Save();
}
