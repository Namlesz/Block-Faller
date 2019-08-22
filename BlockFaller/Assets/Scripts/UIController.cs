using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private float timeLeft;
    private Color targetColor;
    private Text text;

    private void Start()
    {
        text = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        updatedColor();
    }

    void updatedColor()
    {
        if (timeLeft <= Time.deltaTime)
        {
            text.color = targetColor;

            targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            timeLeft = 1.0f;
        }
        else
        {
            text.color = Color.Lerp(text.color, targetColor, Time.deltaTime / timeLeft);

            timeLeft -= Time.deltaTime;
        }
    }
}
