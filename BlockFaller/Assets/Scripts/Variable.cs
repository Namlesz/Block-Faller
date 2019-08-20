using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{
    public float speed;
    public float spawnTime;
    public float destroyEffecttime;
    public static int points;
    public static bool shakeCam;
    public float percentIncerase;
    private void Start()
    {
        points = 0;
        shakeCam = false;
    }
    private void Update()
    {
        //if (points % 10 == 0 && points != 0)
        //{
        //    spawnTime -= spawnTime * percentIncerase;
        //    speed += spawnTime * percentIncerase;
        //}
    }
}
