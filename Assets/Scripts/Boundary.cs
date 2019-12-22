using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    public Text scoreText;
    public GameManager gameManager;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _) {
        score += 1;
        scoreText.text = score.ToString();
        gameManager.Reset();
    }
}
