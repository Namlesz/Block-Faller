using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
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
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    public void OpenUrl() => Application.OpenURL("https://www.termsfeed.com/privacy-policy/75f803f254a2b45064908c82ba3b505b");
    public void Quit() => Application.Quit();
    private void OnApplicationQuit() => PlayerPrefs.Save();
    public void OpenLeaderBoard() => PlayGameScript.ShowLeaderbordUI();
    public void Openachievements() => PlayGameScript.ShowAchievementsUI();
}
