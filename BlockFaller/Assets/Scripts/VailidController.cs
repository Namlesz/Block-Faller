using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VailidController : MonoBehaviour
{
    GameObject square;
    public float rotation = 0;
    public float rotateSpeed;
    private bool isRotating;
    private void Start()
    {
        isRotating = false;
        square = GameObject.Find("SquareValid");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rotation >= 360 || rotation <= -360)
                rotation = 0;

            isRotating = true;

            if (Input.mousePosition.x > Screen.width / 2)
            {
                rotation -= 90;
            }

            if (Input.mousePosition.x < Screen.width / 2)
            {
                rotation += 90;
            }
        }
        Rotate();
    }

    void Rotate()
    {
        if (isRotating)
        {
            Vector3 to = new Vector3(0,0, rotation);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime*rotateSpeed);
            }
            else
            {
                transform.eulerAngles = to;
                isRotating = false;
            }
        }
    }
}
