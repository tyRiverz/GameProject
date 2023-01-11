using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEditor.Progress;

public class SidekickAI : MonoBehaviour
{
    bool onWork = false;
    float cameraHeight = 0f;

    public Transform target;
    public Transform itemTarget;

    public float speed = 1000f;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public int receivedDamage = 10;
    public float hitForce = 10f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool ShieldActive = false;
    Coroutine coroutine = null;


    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        cameraHeight = (cam.orthographicSize+1)*.80f;

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .1f);

    }

    private void UpdatePath()
    {
        if (seeker.IsDone() && target != null)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Düþen itemleri listele
    // Listedeki itemleri sýrasýyla yeni hedef yap      
    // Bir önceki obje toplanmadan listedeki yeni objeye geçme
    // Liste bitince yeni objeleri listeye al
    void ListTaggedObjects()
    {
        onWork = true;

        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");

        if (Items.Length > 0)
        {
            foreach (GameObject item in Items)
            {
                float distance = Vector2.Distance(item.transform.position, GameObject.FindWithTag("Player").transform.position);

                if (distance < cameraHeight)
                {
                    CollectItem(item);

                }
                else
                {
                    target = GameObject.FindWithTag("Player").transform;
                }
            }
        }
        else
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        onWork = false;
    }

    void CollectItem(GameObject receivedItem)
    {
        if (GameObject.Find(receivedItem.name))
        {
            target = receivedItem.transform;
        }
        else
        {
            return;
        }

    }

    void TakeDamage(int damage)
    {
        if(ShieldActive == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(receivedDamage);
        }
        
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
        Debug.Log("Sidekick Shield deactivated");
    }

    public void TakeHp(int Hp)
    {
        currentHealth += Hp;
        healthBar.IncreaseHealth(Hp);
        
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


    // Update is called once per frame
    void FixedUpdate()
    {
        if (onWork == false)
            ListTaggedObjects();

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < speed)
        {
            currentWaypoint++;
        }
    }
}
