using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float bulletspeed;
    [SerializeField] private float shootCooldown = .1f;
    private float Cooldown;

    [SerializeField] public TextMeshProUGUI bulletText;
    [SerializeField] public int maxBullet = 25;
    [SerializeField] public int currentAmountOfBullet;

    void Start()
    {
        Cooldown = shootCooldown;

        GameObject bulletTextUI = GameObject.FindGameObjectWithTag("bulletTextUI");
        bulletText = bulletTextUI.GetComponent<TextMeshProUGUI>();
        currentAmountOfBullet = maxBullet;
        bulletText.text = currentAmountOfBullet + " / " + maxBullet;
    }

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && (shootCooldown <= 0f) )
        {
            currentAmountOfBullet = currentAmountOfBullet - 1;
            bulletText.text = currentAmountOfBullet + " / " + maxBullet;

            GameObject newBullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(-firePoint.transform.right * bulletspeed,ForceMode2D.Impulse);
            Destroy(newBullet,1f);

            shootCooldown = Cooldown;
        }
    }
}
