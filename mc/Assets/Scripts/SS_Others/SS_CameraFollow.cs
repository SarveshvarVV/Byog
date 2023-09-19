using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform leftBounds;
    [SerializeField] Transform rightBounds;

    [SerializeField] float smoothDampTime = 0.15f;
    Vector3 smoothDampVelocity = Vector3.zero;

    float camWidth, camHeight, levelMinX, levelMaxX;

    // Start is called before the first frame update
    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        float leftBoundsWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x/2;
        float rightBoundsWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        levelMinX = leftBounds.position.x + leftBoundsWidth + (camWidth/2);
        levelMaxX = rightBounds.position.x - rightBoundsWidth - (camWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX,target.position.x));
            float x = Mathf.SmoothDamp(transform.position.x, targetX,ref smoothDampVelocity.x, smoothDampTime);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
