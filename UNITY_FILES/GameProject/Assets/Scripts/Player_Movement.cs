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
        // Yatay ve dikey giri�leri al�r
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Giri�ler vekt�re d�n��t�r�l�r, b�y�kl��� hesaplan�r, normalize edilir
        movement = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);                
        movement.Normalize();

        // Objeye haz�rlanan vekt�r kadar hareket kazand�r�l�r
        transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime,Space.World);

        // Objenin hareket etti�i y�ne do�ru bakmas� sa�lan�r
        if(movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
