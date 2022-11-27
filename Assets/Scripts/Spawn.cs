using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject moon;
    [SerializeField] private float spawnFrequency = 4f;
    private bool isSpawning = true;
    // pos x must me between -8 : 8.2
    private float posX;
    private float[] posYList = { -6, 6 };
    private int posY;
    private float moonPosY;

    void Start()
    {
        StartCoroutine(SpawnInTimePeriod(spawnFrequency));
    }
    IEnumerator SpawnInTimePeriod(float timeToSpawn)
    {
        while (isSpawning == true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            SpawnEnemy();
            SpawnMoon();
        }

    }

    private void SpawnEnemy()
    {
        posX = Random.Range(-8, 8);
        posY = Random.Range(0, 2);

        Vector2 positionToSpawn = new Vector2(posX, posYList[posY]);
        Instantiate(enemy, positionToSpawn, Quaternion.identity);
    }

    private void SpawnMoon()
    {
        posX = Random.Range(-8.26f, 8.20f);
        moonPosY = Random.Range(-4.32f, 4.34f);
        Vector2 moonSpawnPosition = new Vector2(posX, moonPosY);
        Instantiate(moon, moonSpawnPosition, Quaternion.identity);
    }
}
