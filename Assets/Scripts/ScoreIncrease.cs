using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    private Spawn spawn;
    private void Awake()
    {
        spawn = GameObject.FindWithTag("Spawner").GetComponent<Spawn>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.IncreaseScore();
            if (GameManager.instance.score % 10 == 0)
            {
                spawn.increaseEnemySpawn();
            }

            Destroy(this.gameObject);
        }
    }
}
