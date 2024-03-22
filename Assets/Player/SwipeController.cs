using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private bool swipeStarted;
    private Vector2 startPoint;

    public float swipeThreshold = 50f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeStarted = true;
            startPoint = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swipeStarted = false;
            Vector2 endPoint = Input.mousePosition;
            float swipeDistance = (endPoint - startPoint).magnitude;

            if (swipeDistance >= swipeThreshold)
            {
                Vector2 swipeDirection = endPoint - startPoint;
                swipeDirection.Normalize();

                if (swipeDirection.x < -0.5f && Mathf.Abs(swipeDirection.y) < 0.5f)
                {
                    Debug.Log("Left swipe detected");
                }
                else if (swipeDirection.x > 0.5f && Mathf.Abs(swipeDirection.y) < 0.5f)
                {
                    Debug.Log("Right swipe detected");
                }
                else if (swipeDirection.y > 0.5f && Mathf.Abs(swipeDirection.x) < 0.5f)
                {
                    Debug.Log("Up swipe detected");
                    GetComponent<Animator>().SetTrigger("jump");
                }
                else if (swipeDirection.y < -0.5f && Mathf.Abs(swipeDirection.x) < 0.5f)
                {
                    Debug.Log("Down swipe detected!");
                    GetComponent<Animator>().SetTrigger("slide");
                }
            }
        }
    }
}
