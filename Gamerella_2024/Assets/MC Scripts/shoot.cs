using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;           
    [SerializeField] GameObject firePoint;              
    [SerializeField] float bulletSpeed;                 
    [SerializeField] private float shootCooldown = 0.1f; 
    private float currentShootCooldown;                 

    [SerializeField] public TextMeshProUGUI bulletText;  
    [SerializeField] public int maxBullet = 25;         
    [SerializeField] public int currentAmountOfBullet;

    public AudioSource reloadAudio;
    public AudioSource gunshotAudio;

    void Start()
    {
        currentShootCooldown = shootCooldown;

        GameObject bulletTextUI = GameObject.FindGameObjectWithTag("bulletTextUI");
        bulletText = bulletTextUI.GetComponent<TextMeshProUGUI>();
        currentAmountOfBullet = maxBullet;
        UpdateBulletText();

        reloadAudio = GetComponents<AudioSource>()[0];
       
        gunshotAudio = GetComponents<AudioSource>()[1];
    }

    void Update()
    {
        
        if (currentAmountOfBullet > 0)
        {
            currentShootCooldown -= Time.deltaTime;  

            if (Input.GetMouseButtonDown(0) && currentShootCooldown <= 0f)
            {
                gunshotAudio.Play();
                FireBullet();

                
                currentShootCooldown = shootCooldown;
            }
        }
        else
        {
            
            ReloadBullets();
        }
    }

    private void FireBullet()
    {
        currentAmountOfBullet--;  
        UpdateBulletText();        

        
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(-firePoint.transform.right * bulletSpeed, ForceMode2D.Impulse);

        
        Destroy(newBullet, 1f);
    }

    private void ReloadBullets()
    {
        reloadAudio.Play();
        currentAmountOfBullet = maxBullet;
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        
        bulletText.text = currentAmountOfBullet + " / " + maxBullet;
    }
}
