using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 0.1f;
    private float horizontalMovent;
    private float verticalMovent;
    private float rotation;
    // Start is called before the first frame update

    void Start()
    {
        rotation = Random.Range(20, 70);
        rb2d = GetComponent<Rigidbody2D>();
        setYmove();
        setXmove();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        MoonMove();
    }

    private void setYmove()
    {
        if (gameObject.transform.position.y < 0)
        {
            verticalMovent = 1;
        }
        else
        {
            verticalMovent = -1;
        }
    }

    private void setXmove()
    {
        if (gameObject.transform.position.x > 6.5)
        {
            horizontalMovent = Random.Range(0, 2);
        }
        else
        {
            horizontalMovent = Random.Range(-1, 1);
        }
    }

    private void MoonMove()
    {
        rb2d.velocity = new Vector2(horizontalMovent * speed, verticalMovent * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
