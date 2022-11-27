using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;

    // pos x must me between -8 : 8.2
    private float posX;
    private float[] posYList = { -6, 6 };
    private int posY;
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        posX = Random.Range(-8, 8);
        posY = Random.Range(0, 2);

        Vector2 positionToSpawn = new Vector2(posX, posYList[posY]);
        Instantiate(enemy, positionToSpawn, Quaternion.identity);
    }
}
