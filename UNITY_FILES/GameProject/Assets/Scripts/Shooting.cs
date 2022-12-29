using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;

    float fireDelay = 300;
    float nextFire = 0;

    // Update is called once per frame
    void Update()
    {
        // Saniyede bir ateþ edilecek þekilde zamanlama ayarlanýr

        if (Time.time * 1000 > nextFire)
        {
            nextFire = (Time.time * 1000) + fireDelay; // delay the next fire by the fireDelay
            Shoot();
        }

    }

    void Shoot()
    {
        // Mermi objesinin pozisyonu alýnarak çýkýþ doðrultusuna belirli kuvvetle salýnýr

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }
}
