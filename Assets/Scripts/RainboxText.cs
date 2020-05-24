using UnityEngine;
using UnityEngine.UI;

public class RainboxText : MonoBehaviour
{
    public float colorChangeDuration = 1f;

    Text text;
    Color targetColor;
    Color currentColor;
    float timeSinceChange;

    void Start()
    {
        text = GetComponent<Text>();
        timeSinceChange = 0f;
        currentColor = text.color;
        targetColor = Random.ColorHSV();
    }

    void Update()
    {
        if (timeSinceChange >= colorChangeDuration)
        {
            currentColor = targetColor;
            targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            timeSinceChange = 0f;
        }
        timeSinceChange += Time.deltaTime;
        text.color = Color.Lerp(currentColor, targetColor, timeSinceChange / colorChangeDuration);
    }
}
