using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{

    private float currentTime;
    public GameObject[] shapes;
    private Variable vars;
    private void Start()
    {
        vars = GameObject.Find("GameController").GetComponent<Variable>();
        currentTime = 0;
    }
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= vars.spawnTime)
        {
            int randShape = Random.Range(0, 3);
            Instantiate(shapes[randShape], new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
            currentTime = 0;
        }
    }
}
