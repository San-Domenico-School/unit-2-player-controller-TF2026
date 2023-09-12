using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/****************************
 * Component of the Vehicle, takes in user
 * input of move and turn the vehicle
 * 
 * Teddy Fleitas
 * September 11, 2023 Version 17.6
 ****************************/

public class PlayerController : MonoBehaviour
{

    private float speed;           // holds the forward movement of the vehicle
    private float turnSpeed;       // holds the turn speed of the vehicle
    private float verticalInput;   // gets a value [-1, 1] from the user key press up/down or W/S
    private float horizontalInput; // gets a value [-1, 1] from the user key press left/right or A/S

    private Rigidbody rb;          // points to vehicle ridigbody component

    // Start is called before the first frame update
    void Start()
    {
        speed = 200.0f;
        turnSpeed = 50.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
    }

    // Called from PlayerAActionInput when user presses WASD or arrow keys
    private void OnMove(InputValue input)
    {
        verticalInput = input.Get<Vector2>().y;
        horizontalInput = input.Get<Vector2>().x;
    }
}
