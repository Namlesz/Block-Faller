using UnityEngine;

public class RotationController : MonoBehaviour
{
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rotation = 0;
    private float rotationProgress = -1;
    public Sprite[] circleSprites;
    private SpriteRenderer sprite;
    private int startPos;

    private void Start()
    {
        startPos = 0;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = circleSprites[startPos];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                ChangeSpriteAndRotation(-1,-90);
            }

            if (Input.mousePosition.x < Screen.width / 2)
            {
                ChangeSpriteAndRotation(1,90);
            }
            StartRotating(rotation);
        }
        ContinueRotToEnd();
    }

    private void FixedUpdate()
    {
        ContinueRotToEnd();
    }

    void ChangeSpriteAndRotation(int i, int rot)
    {
        rotation += rot;
        startPos += i;

        if (startPos < 0)
        {
            startPos = 3;
        }

        if (startPos > 3)
        {
            startPos = 0;

        }
        sprite.sprite = circleSprites[startPos];
    }

    void StartRotating(float zPosition)
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zPosition);
        rotationProgress = 0;
    }

    void ContinueRotToEnd()
    {
        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 5;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }
    }
}
