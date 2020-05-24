using UnityEngine;
using System.Collections.Generic;

public class PaddleAIProducer : Producer<Vector2>
{
    public GameManager gameManager;
    public float forceFactor = 10.0f;
    public float minActivationDelta = 0.25f;
    [Range(0f, 1f)]
    public float easyErrorProbability = 0.5f;
    [Range(0f, 1f)]
    public float mediumErrorProbability = 0.25f;
    [Range(0f, 1f)]
    public float hardErrorProbability = 0.0f;

    GameObject _ball;
    bool _alreadyGot = false;

    void Awake()
    {
        _ball = null;
    }

    GameObject GetBall()
    {
        if (_ball == null)
        {
            _alreadyGot = false;
        }

        if (!_alreadyGot)
        {
            var maybeBall = GameObject.FindWithTag("Ball");
            if (maybeBall != null)
            {
                _ball = maybeBall;
                _alreadyGot = true;
            }
        }
        return _ball;
    }

    override public Vector2 Produce()
    {
        var direction = 0;
        var ball = GetBall();
        if (ball != null)
        {
            var ballY = ball.transform.position.y;
            var thisY = transform.position.y;
            var delta = ballY - thisY;
            if (Mathf.Abs(delta) >= minActivationDelta)
                direction = Mathf.RoundToInt(Mathf.Sign(delta));
        }

        var directionChangeRoll = Random.Range(0f, 1f);
        switch (gameManager.difficulty)
        {
            case 0:
                if (directionChangeRoll < easyErrorProbability)
                {
                    Debug.Log("Easy: changed direction!");
                    direction = -direction;
                }
                break;
            case 1:
                if (directionChangeRoll < mediumErrorProbability)
                {
                    Debug.Log("Medium: changed direction!");
                    direction = -direction;
                }
                break;
            case 2:
                if (directionChangeRoll < hardErrorProbability)
                {
                    Debug.Log("Hard: changed direction!");
                    direction = -direction;
                }
                break;
            default:
                break;
        }

        var newValue = Vector2.zero;
        if (direction != 0)
            newValue = Mathf.Sign(direction) > 0 ? Vector2.up : Vector2.down;

        return newValue * forceFactor * Time.deltaTime;
    }
}