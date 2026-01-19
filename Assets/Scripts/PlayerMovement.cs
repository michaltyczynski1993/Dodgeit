using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float playerSpeed;
    float smooth = 4.0f;
    float tiltAngle = 90.0f;
    public AudioSource engine;
    private bool isPlayerMove;
   private Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isPlayerMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            MovePlayer();
        }
        else { rb2d.linearVelocity = new Vector2(0, 0); }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {;
        rb2d.linearVelocity = new Vector2(
        movementInput.x * playerSpeed,
        movementInput.y * playerSpeed
    );

    if (movementInput.x > 0.1f)
    {
        tiltAngle = -45f;
        isPlayerMove = true;
    }
    else if (movementInput.x < -0.1f)
    {
        tiltAngle = 45f;
        isPlayerMove = true;
    }
    else
    {
        tiltAngle = 0f;
        isPlayerMove = false;
    }

    RotatePlayer(tiltAngle, smooth);
    }
    private void RotatePlayer(float rotAngle, float rotSpeed)
    {
        rb2d.MoveRotation(Mathf.LerpAngle(rb2d.rotation, rotAngle, rotSpeed * Time.deltaTime));
    }
}
