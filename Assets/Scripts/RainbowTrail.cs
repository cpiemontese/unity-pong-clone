using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTrail : MonoBehaviour
{
    public float colorChangeDuration = 1f;

    TrailRenderer trailRenderer;
    Color targetColor;
    Color currentColor;
    float timeSinceChange;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        timeSinceChange = 0f;
        currentColor = trailRenderer.startColor;
        targetColor = Random.ColorHSV();
    }

    void Update()
    {
        if (timeSinceChange >= colorChangeDuration)
        {
            currentColor = targetColor;
            targetColor = Random.ColorHSV();
            timeSinceChange = 0f;
        }
        timeSinceChange += Time.deltaTime;
        trailRenderer.startColor = Color.Lerp(currentColor, targetColor, timeSinceChange/colorChangeDuration);
    }
}
