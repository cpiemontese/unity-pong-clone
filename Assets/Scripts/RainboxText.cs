using UnityEngine;
using UnityEngine.UI;

public class RainboxText : MonoBehaviour
{
    public float colorChangeDuration = 1f;

    Text text;
    Color targetColor;
    Color currentColor;
    float timeSinceChange;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        timeSinceChange = 0f;
        currentColor = text.color;
        targetColor = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceChange >= colorChangeDuration)
        {
            currentColor = targetColor;
            targetColor = Random.ColorHSV();
            timeSinceChange = 0f;
        }
        timeSinceChange += Time.deltaTime;
        text.color = Color.Lerp(currentColor, targetColor, timeSinceChange/colorChangeDuration);
    }
}
