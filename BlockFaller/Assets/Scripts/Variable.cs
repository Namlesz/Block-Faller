using UnityEngine;
using UnityEngine.UI;

public class Variable : MonoBehaviour
{
    public static bool shakeCam;
    public static bool lostFlag;
    private static int points;

    public float speed;
    public float spawnTime;
    public float destroyEffecttime;
    public float percentIncerase;

    public int lives;

    private Text score;
    private GameObject[] heart;
    public AudioClip pointAudio;
    public AudioClip hurtAudio;
    public AudioClip gameEndAudio;
    private AudioSource audios;
    private GameObject lostView;


    private void Start()
    {
        PlayGameScript.UnlockAchievement(GPGSIds.achievement_first_play);

        lostView = GameObject.Find("LostView");
        lostView.gameObject.SetActive(false);
        audios = GetComponent<AudioSource>();
        points = 0;
        shakeCam = lostFlag = false;
        heart = GameObject.FindGameObjectsWithTag("Heart");
        score = GameObject.Find("Score").GetComponent<Text>();
        lives = 3;
        Application.targetFrameRate = 300;
    }

    public void AddPoint(int point)
    {
        PlayGameScript.UnlockAchievement(GPGSIds.achievement_first_point);

        points += point;
        score.text = points.ToString();
        audios.PlayOneShot(pointAudio);
    }

    public void Hurt(int hitPoint)
    {
        audios.PlayOneShot(hurtAudio);
        lives -= hitPoint;
        Destroy(heart[lives].gameObject);
        if (lives <= 0)
            EndGame();
    }
    private void EndGame()
    {
        GoogleGameServices_End(points);
        SetHigscoreLocal(points);

        audios.PlayOneShot(gameEndAudio);
        lostFlag = true;
        lostView.gameObject.SetActive(true);
        GameObject.Find("SquareValid").gameObject.SetActive(false);
        GameObject.Find("InGameView").gameObject.SetActive(false);

        GameObject.Find("EndScore").GetComponent<Text>().text = points.ToString();
    }

    private void GoogleGameServices_End(int points)
    {
        PlayGameScript.AddScoreToLeaderboard(GPGSIds.leaderboard_top_scores, points);
        PlayGameScript.IncrementAchievement(GPGSIds.achievement_10_points, points);
        PlayGameScript.IncrementAchievement(GPGSIds.achievement_first_die, points);
        PlayGameScript.IncrementAchievement(GPGSIds.achievement_100_points, points);
        PlayGameScript.IncrementAchievement(GPGSIds.achievement_you_are_awesome, 1);
    }

    private void SetHigscoreLocal(int points)
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", points);
        }
        else if (PlayerPrefs.GetInt("Highscore") < points)
        {
            PlayGameScript.UnlockAchievement(GPGSIds.achievement_beat_your_highscore);
            PlayerPrefs.SetInt("Highscore", points);
        }
    }
}
