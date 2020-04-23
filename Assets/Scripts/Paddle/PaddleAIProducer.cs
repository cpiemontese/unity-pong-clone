using UnityEngine;

public class PaddleAIProducer : Producer<Vector2> {
    public float forceFactor = 10.0f;
    public float minActivationDelta = 0.25f;

    GameObject _ball;
    bool _alreadyGot = false;

    void Start()
    {
        _ball = null;
    }

    GameObject GetBall() {
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

    override public Vector2 Produce() {
        var newValue = Vector2.zero;
        var ball = GetBall();
        if (ball != null) {
            var ballY = ball.transform.position.y;
            var thisY = transform.position.y;
            var delta = ballY - thisY;
            if (Mathf.Abs(delta) >= minActivationDelta) {
                newValue = Mathf.Sign(ballY - thisY) > 0 ? Vector2.up : Vector2.down;
            }
        }
        return newValue * forceFactor * Time.deltaTime;
    }
}