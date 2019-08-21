using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variable : MonoBehaviour
{
    public float speed;
    public float spawnTime;
    public float destroyEffecttime;
    public static int points;
    public static bool shakeCam;
    public float percentIncerase;

    private Text score; 
    private void Start()
    {
        points = 0;
        shakeCam = false;
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    public void AddPoint(int point)
    {
        score.text = points.ToString();
    }

}
