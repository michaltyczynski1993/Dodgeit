using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float playerSpeed;
    float smooth = 4.0f;
    float tiltAngle = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            MovePlayer();
        }
        else { rb2d.velocity = new Vector2(0, 0); }

    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);

        switch (horizontalInput)
        {
            case 1:
                tiltAngle = -45f;
                RotatePlayer(tiltAngle, smooth);
                break;

            case 0:
                tiltAngle = 0f;
                RotatePlayer(tiltAngle, smooth);
                break;


            case -1:
                tiltAngle = 45f;
                RotatePlayer(tiltAngle, smooth);
                break;
        }
    }
    private void RotatePlayer(float rotAngle, float rotSpeed)
    {
        rb2d.MoveRotation(Mathf.LerpAngle(rb2d.rotation, rotAngle, rotSpeed * Time.deltaTime));
    }
}
