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
            
            if(vars.speed < 450)
            {
                vars.speed += vars.speed * vars.percentIncerase;
            }
            else
            {
                vars.speed += vars.speed * 0.001f;
            }


            if (vars.spawnTime > 0.6f)
                vars.spawnTime -= vars.spawnTime * vars.percentIncerase;
            else if (vars.spawnTime > 0.3)
                vars.spawnTime -= vars.spawnTime * 0.01f;
            else
                vars.spawnTime = 0.299f;
        }
    }
}
