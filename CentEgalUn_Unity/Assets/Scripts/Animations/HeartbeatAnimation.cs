using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatAnimation : MonoBehaviour
{
    public float beatDuration = 3.0f;
    public float scaleAmount = 1.2f;
    
    private void Start()
    {
        // Start the heartbeat animation
        Beat();
    }

    private void Beat()
    {
        // Scale up the heart
        LeanTween.scale(gameObject, new Vector3(scaleAmount, scaleAmount, 1f), beatDuration / 2)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(Shrink);
    }

    private void Shrink()
    {
        // Scale down the heart
        LeanTween.scale(gameObject, Vector3.one, beatDuration / 2)
            .setEase(LeanTweenType.easeInQuad)
            .setOnComplete(Beat);
    }
}
