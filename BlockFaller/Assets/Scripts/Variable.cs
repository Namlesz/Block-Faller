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
    private void Start()
    {
        points = 0;
        shakeCam = false;
    }
}
