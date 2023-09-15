using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float turnSpeed;
    private float verticalInput;
    private float horizontalInput;

    private Rigidbody rb;

    // New variables for flying
    public float flySpeed = 150000.0f; // Adjust this to control the fly speed.

    // Start is called before the first frame update
    void Start()
    {
        speed = 150.0f;
        turnSpeed = 90.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Scorekeeper.Instance.AddToScore(verticalInput);
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);

        // Check for input to move the car vertically
        if (Keyboard.current.spaceKey.isPressed)
        {
            // Move up
            rb.AddForce(Vector3.up * flySpeed);
        }
        else if (Keyboard.current.leftShiftKey.isPressed)
        {
            // Move down
            rb.AddForce(Vector3.down * flySpeed);
        }
    }

    // Called from PlayerAActionInput when user presses WASD or arrow keys
    private void OnMove(InputValue input)
    {
        verticalInput = input.Get<Vector2>().y;
        horizontalInput = input.Get<Vector2>().x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Scorekeeper.Instance.SubtractFromScore();
        }
    }
}
