using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VailidController : MonoBehaviour
{
    public float rotation = 0;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rotationProgress = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rotation >= 360 || rotation <= -360)
                rotation = 0;


            if (Input.mousePosition.x > Screen.width / 2)
            {
                rotation -= 90;
            }

            if (Input.mousePosition.x < Screen.width / 2)
            {
                rotation += 90;
            }
            StartRotating(rotation);

        }

        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 5;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }
    }

    void StartRotating(float zPosition)
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zPosition);
        rotationProgress = 0;
    }
}
