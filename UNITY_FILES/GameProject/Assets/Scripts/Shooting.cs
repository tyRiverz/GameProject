using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
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
        if (UpgradeMenu.TypeLevel == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (UpgradeMenu.TypeLevel == 2)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (UpgradeMenu.TypeLevel == 3)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            rb4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet5 = Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
            Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
            rb5.AddForce(firePoint5.up * bulletForce, ForceMode2D.Impulse);
          
        }


    }
}
