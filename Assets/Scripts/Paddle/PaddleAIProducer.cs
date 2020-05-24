using UnityEngine;
using System.Collections.Generic;

public class PaddleAIProducer : Producer<Vector2>
{
    public GameManager gameManager;
    public float movementSpeed = 10.0f;
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
        var vx = 0f;
        var ball = GetBall();
        if (ball != null)
        {
            var ballY = ball.transform.position.y;
            var thisY = transform.position.y;
            var delta = ballY - thisY;
            if (Mathf.Abs(delta) >= minActivationDelta)
                vx = Mathf.Sign(delta);
        }

        var directionChangeRoll = Random.Range(0f, 1f);
        var flipVx = false;
        switch (gameManager.difficulty)
        {
            case 0:
                flipVx = directionChangeRoll < easyErrorProbability;
                break;
            case 1:
                flipVx = directionChangeRoll < mediumErrorProbability;
                break;
            case 2:
                flipVx = directionChangeRoll < hardErrorProbability;
                break;
            default:
                Debug.LogWarning($"Unknown difficulty {gameManager.difficulty}");
                break;
        }

        if (flipVx)
        {
            vx = -vx;
        }

        return new Vector2(0f, vx * movementSpeed);
    }
}