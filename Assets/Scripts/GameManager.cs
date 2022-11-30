using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variables
    public static GameManager instance;

    public bool isGameOver = false;

    // enemy speed and spawn time
    public float enemySpeed = 2f;
    public int score;

    private void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    private void Start()
    {
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log(score);
    }

}
