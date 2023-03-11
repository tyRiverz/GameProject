using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
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

    private DeathMenu dm;

    Material materialPlayer;
    Material materialShield;
    GameObject shield;
    bool isBorning = true;
    bool ShieldGrown = false;
    float fade = 0f;
    float fadeShield = 0f;    

    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("Ambience");        
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        dm = GameObject.Find("Canvas").GetComponent<DeathMenu>();
        materialPlayer = GetComponent<SpriteRenderer>().material;
        materialShield = GameObject.Find("ShieldZone").GetComponent<SpriteRenderer>().material;
        shield = GameObject.Find("ShieldZone");
        shield.SetActive(false);

    }

    public void ShieldCountdown(float time)
    {
        // Belirli süre kalkaný aç
        if (coroutine != null)
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
        //Debug.Log("Player Shield deactivated");
    }


    void TakeDamage(int damage)
    {
        if (ShieldActive == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(receivedDamage);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        AudioManager.isPlayerDead = true;

        DeathMenu.GameIsPaused = true;
        dm.DeathMenuUI.SetActive(true);
        //TODO DeathEffect animasyon eklenecek
    }

    public void TakeHp(int Hp)
    {
        currentHealth += Hp;
        healthBar.IncreaseHealth(Hp);
        //Debug.Log(Hp.ToString() + " taken");
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        TakeDamage(receivedDamage);

    //        Vector2 direction = (rb.position - (Vector2)GameObject.FindWithTag("Enemy").transform.position).normalized;
    //        Vector2 force = direction * hitForce * Time.deltaTime;

    //        rb.AddForce(force, ForceMode2D.Impulse);
    //    }
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        rb.velocity = Vector3.zero;
    //        Debug.Log("Wall Collision");
    //    }
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(receivedDamage);

            Vector2 direction = (rb.position - (Vector2)GameObject.FindWithTag("Enemy").transform.position).normalized;
            Vector2 force = direction * hitForce * Time.deltaTime;

            rb.AddForce(force, ForceMode2D.Impulse);
        }
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    rb.velocity = Vector3.zero;
        //    Debug.Log("Wall Collision");
        //}
    }

    private void FixedUpdate()
    {
        if (isBorning)
        {
            fade += Time.fixedDeltaTime;

            if (fade >= 1f)
            {
                fade = 1f;
                isBorning = false;
                Shooting.charBorn = true;
            }

            materialPlayer.SetFloat("_Fade", fade);
        }

        if (ShieldActive)
        {
            //Debug.Log("Shield shader girdi");
            if (ShieldGrown == false)
            {
                shield.SetActive(true);

                fadeShield += Time.fixedDeltaTime;

                if (fadeShield >= 1f)
                {
                    fadeShield = 1f;
                }
                materialShield.SetFloat("_Fade", fadeShield);

                if (fadeShield == 1f)
                {
                    ShieldGrown = true;
                }
            }
        }
        else
        {
            if (shield)
            {
                
                if (fadeShield > 0f)
                {
                    ShieldGrown = false;

                    fadeShield -= Time.fixedDeltaTime;

                    if (fadeShield <= 0f)
                    {
                        fadeShield = 0f;
                    }
                    materialShield.SetFloat("_Fade", fadeShield);

                    if (fadeShield == 0f)
                    {
                        shield.SetActive(false);
                    }
                }
            }

        }        

        // Yatay ve dikey giriþleri alýr
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        
        // Giriþler vektöre dönüþtürülür, büyüklüðü hesaplanýr, normalize edilir

        transform.Rotate(0, 0, -10*horizontalInput);

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            movement = transform.right;
            float inputMagnitude = Mathf.Clamp01(movement.magnitude);
            movement.Normalize();
            transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime, Space.World);
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            movement = -transform.right;
            float inputMagnitude = Mathf.Clamp01(movement.magnitude);
            movement.Normalize();
            transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime, Space.World);
        }
        //else
        //{
        //    movement = new Vector2(0, 0);
        //}

        //movement = new Vector2(horizontalInput, verticalInput);

        //float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        //movement.Normalize();

        // Objeye hazýrlanan vektör kadar hareket kazandýrýlýr
        //transform.Translate(movement * moveSpeed * inputMagnitude * Time.fixedDeltaTime, Space.World);

        //Objenin hareket ettiði yöne doðru bakmasý saðlanýr
        //if (movement != Vector2.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        //}
    }
}
