using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;

    GameObject ballInstance;

    void Start()
    {
        ballInstance = Instantiate(ballPrefab);
    }

    public void Reset()
    {
        Destroy(ballInstance);
        ballInstance = Instantiate(ballPrefab);
    }
}
