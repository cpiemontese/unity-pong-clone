using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    public Text scoreText;
    public GameManager gameManager;

    int score;

    void Start()
    {
        score = 0;   
    }

    void OnTriggerEnter2D(Collider2D _) {
        score += 1;
        scoreText.text = score.ToString();
        gameManager.Reset();
    }
}
