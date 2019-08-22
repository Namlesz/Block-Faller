using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        points = 0;
        shakeCam = lostFlag = false;
        heart = GameObject.FindGameObjectsWithTag("Heart");
        score = GameObject.Find("Score").GetComponent<Text>();
        lives = 3;
    }

    public void AddPoint(int point)
    {
        points += point;
        score.text = points.ToString();
    }

    public void Hurt(int hitPoint)
    {
        lives -= hitPoint;
        Destroy(heart[lives].gameObject);
        if (lives <= 0)
            lostFlag = true;
    }
}
