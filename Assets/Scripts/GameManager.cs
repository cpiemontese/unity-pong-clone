using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Difficulty difficulty = Difficulty.Normal;
    public GameObject ballPrefab;

    GameObject ballInstance;

    // Start is called before the first frame update
    void Start()
    {
        ballInstance = Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Destroy(ballInstance);
        ballInstance = Instantiate(ballPrefab);
    }
}
