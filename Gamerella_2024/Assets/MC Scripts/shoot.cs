using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float bulletspeed;
    [SerializeField] private float shootCooldown = .5f;
    private float Cooldown;

    void Start()
    {
        Cooldown = shootCooldown;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && (shootCooldown <= 0f) )
        {
            GameObject newBullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(-firePoint.transform.right * bulletspeed,ForceMode2D.Impulse);
            Destroy(newBullet,1f);

            shootCooldown = Cooldown;
        }
    }
}
