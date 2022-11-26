using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 2;
    private float horizontalMovent;
    private float verticalMovent;
    // Start is called before the first frame update

    private void Awake()
    {
        horizontalMovent = Random.Range(-1, 1);
        verticalMovent = Random.Range(-1, 1);
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        rb2d.velocity = new Vector2(horizontalMovent * speed, verticalMovent * speed);
    }

}

