using UnityEngine;

public class PaddleAIProducer : Producer<Vector2> {
    GameObject _ball;
    bool _alreadyGot = false;

    void Start()
    {
    }

    GameObject GetBall() {
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

    override public Vector2 produce() {
        var newValue = Vector2.zero;
        var ball = GetBall();
        if (ball != null) {
            var ballY = ball.transform.position.y;
            var thisY = transform.position.y;
            if (thisY < ballY) {
                newValue = Vector2.up;
            } else if (thisY > ballY) {
                newValue = Vector2.down;
            }
        }
        return newValue;
    }
}