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
    public bool ShieldActive = false;
    Coroutine coroutine = null;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void ShieldCountdown(float time)
    {
        // Belirli süre kalkaný aç
        if(coroutine!= null)
        {
            StopCoroutine(coroutine);

        }
        coroutine = StartCoroutine(ExecuteAfterTime(time));
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        // Kalkanýn geri sayým kodu
        yield return new WaitForSeconds(time);

        ShieldActive = false;
        Debug.Log("Player Shield deactivated");
    }


    void TakeDamage(int damage)
    {
        if (ShieldActive == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(receivedDamage);
        }
    }

    public void TakeHp(int Hp)
    {
        currentHealth += Hp;
        healthBar.IncreaseHealth(Hp);
        Debug.Log(Hp.ToString() + " taken");
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(receivedDamage);

            Vector2 direction = (rb.position - (Vector2)GameObject.FindWithTag("Enemy").transform.position).normalized;
            Vector2 force = direction * hitForce * Time.deltaTime;

            rb.AddForce(force, ForceMode2D.Impulse);

            
        }
    }

    private void FixedUpdate()
    {
        // Yatay ve dikey giriþleri alýr
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Giriþler vektöre dönüþtürülür, büyüklüðü hesaplanýr, normalize edilir
        movement = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();

        // Objeye hazýrlanan vektör kadar hareket kazandýrýlýr
        transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime, Space.World);

        // Objenin hareket ettiði yöne doðru bakmasý saðlanýr
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
