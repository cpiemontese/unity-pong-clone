﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    GameObject ballInstance;

    // Start is called before the first frame update
    void Start()
    {
        ballInstance = Instantiate(ball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Destroy(ballInstance);
        ballInstance = Instantiate(ball);
    }
}
