using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{
    public float speed;
    public float spawnTime;
    public static int points;
    private void Start()
    {
        points = 0;
    }
}
