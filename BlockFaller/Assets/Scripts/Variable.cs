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
        audios.PlayOneShot(gameEndAudio);
        lostFlag = true;
        lostView.gameObject.SetActive(true);
        GameObject.Find("SquareValid").gameObject.SetActive(false);
        GameObject.Find("InGameView").gameObject.SetActive(false);

        GameObject.Find("EndScore").GetComponent<Text>().text = points.ToString();
    }
}
