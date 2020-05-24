using UnityEngine;

public class HumanPaddle : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vx = Input.GetAxis("Vertical");
        _rigidBody.velocity = new Vector2(0f, vx * movementSpeed);
    }
}