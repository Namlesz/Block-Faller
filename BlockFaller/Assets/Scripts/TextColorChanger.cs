using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    private float timeLeft;
    private Color targetColor;
    public GameObject[] texts;

    //private void Start()
    //{

    //}

    void Update()
    {
        updatedColor();
    }

    void updatedColor()
    {
        if (timeLeft <= Time.deltaTime)
        {
            foreach(var text in texts)
            {
                text.GetComponent<Text>().color = targetColor;
            }
            targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            timeLeft = 1.0f;
        }
        else
        {
            foreach (var text in texts)
            {
                text.GetComponent<Text>().color = Color.Lerp(text.GetComponent<Text>().color, targetColor, Time.deltaTime / timeLeft); ;
            }
            timeLeft -= Time.deltaTime;
        }
    }
}
