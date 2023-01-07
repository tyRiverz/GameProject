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

    public int maxHealth = 100;
    public int currentHealth;
    public int receivedDamage = 10;
    public float hitForce = 10f;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(receivedDamage);

            Vector2 direction = (rb.position - (Vector2)GameObject.FindWithTag("Enemy").transform.position).normalized;
            Vector2 force = direction * hitForce * Time.deltaTime;
            Debug.Log(direction);
            rb.AddForce(force,ForceMode2D.Impulse);

            healthBar.SetHealth(receivedDamage);
        }
    }

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
