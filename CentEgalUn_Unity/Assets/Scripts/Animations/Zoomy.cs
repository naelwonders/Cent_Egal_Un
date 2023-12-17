using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomy : MonoBehaviour
{
    public float zoomFactor = 1.2f; // Adjust this value in the Inspector to control the zoom factor
    public float minScale = 0.5f; // Minimum scale value
    public float maxScale = 2.0f; // Maximum scale value
    public float zoomDuration = 1.0f; // Duration of a single zoom/unzoom cycle when zooming indefinitely

    private Vector3 originalScale;
    private bool isZoomed = false;
    private bool isZooming = false;

    

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void ZoomOnce()
    {
        if (!isZooming)
        {
            isZoomed = !isZoomed;
            StartCoroutine(ZoomCoroutine(isZoomed ? maxScale : minScale, zoomDuration));
        }
    }

    public void ZoomIndefinitely()
    {
        if (!isZooming)
        {
            isZooming = true;
            StartCoroutine(ZoomIndefinitelyCoroutine());
        }
    }

    private IEnumerator ZoomCoroutine(float targetScale, float duration)
    {
        isZooming = true;
        Vector3 startScale = transform.localScale;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.localScale = Vector3.Lerp(startScale, new Vector3(targetScale, targetScale, transform.localScale.z), t);
            yield return null;
        }

        transform.localScale = new Vector3(targetScale, targetScale, transform.localScale.z);
        isZooming = false;
    }

    private IEnumerator ZoomIndefinitelyCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(ZoomCoroutine(isZoomed ? maxScale : minScale, zoomDuration));
            isZoomed = !isZoomed;
        }
    }
}

