using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Rigidbody2D rb;
    Vector2 movement;
    public float horizontalInput = 0f;
    public float verticalInput = 0f;
  
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);                
        movement.Normalize();

        transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime,Space.World);

        if(movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
