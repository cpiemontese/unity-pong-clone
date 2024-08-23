using UnityEngine;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    public Text scoreText;
    public GameManager gameManager;

    public enum BoundaryType
    {
        Player,
        AI
    }

    public BoundaryType boundaryType;

    int score;

    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score += 1;

        if (boundaryType == BoundaryType.Player)
        {
            gameManager.ScorePlayer();
        }
        else if (boundaryType == BoundaryType.AI)
        {
            gameManager.ScoreAI();
        }

        scoreText.text = score.ToString();
        other.gameObject.GetComponent<Ball>().Reset();
    }
}
