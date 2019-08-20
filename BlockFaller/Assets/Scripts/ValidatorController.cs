using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatorController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag(col.tag))
        {
            Variable.points++;
            Debug.Log(Variable.points);
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
            Debug.Log("Mistake!");
        }
    }
}
