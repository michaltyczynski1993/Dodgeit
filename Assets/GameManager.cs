using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variables
    private static GameManager instance;
    public static GameManager Instance;

    private void Awake()
    {
        instance = this;

        if (instance == null)
        {
            Debug.Log("Game Manager is null!!!");
        }
    }
}
