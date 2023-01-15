using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;

    public static float fireDelay = 400;
    float nextFire = 0;

    public static int BulletSpeed = 1000; 

    // Update is called once per frame
    void Update()
    {
        // Saniyede bir ateþ edilecek þekilde zamanlama ayarlanýr

        if (Time.time * BulletSpeed > nextFire)
        {
            nextFire = (Time.time * BulletSpeed) + fireDelay; // delay the next fire by the fireDelay
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
