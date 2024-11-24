using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 10; 
    public float damageInterval = 3f;
    public int hearthDamage = 5;
    
    public float hearthdamageInterval = 3f;
    private float timeSinceLastDamageHearth = 0f;

    private float timeSinceLastDamage = 0f;  // Timer to track time since the last damage

    private AudioSource hitSound;


    void Start()
    {
        // Optionally initialize any variables here
        hitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arson"))
        {
            hitSound.Play();
            GlobalVariables.SetArsonHealth(damage);
        }

        if (collision.gameObject.CompareTag("hearth"))
        {
            hitSound.Play();
            GlobalVariables.SetHearthHealth(hearthDamage);
        }

    }
    private void OnCollisionStay2D(Collision2D collision) {
       
        if (collision.gameObject.CompareTag("arson"))
        {

            
            timeSinceLastDamage += Time.deltaTime;

            
            if (timeSinceLastDamage >= damageInterval)
            {
                hitSound.Play();
                GlobalVariables.SetArsonHealth(damage);

                
                timeSinceLastDamage = 0f;
            }
        }

        if (collision.gameObject.CompareTag("hearth"))
        {

           
            timeSinceLastDamageHearth += Time.deltaTime;

            
            if (timeSinceLastDamageHearth >= hearthdamageInterval)
            {
                hitSound.Play();
                GlobalVariables.SetHearthHealth(hearthDamage);
                timeSinceLastDamageHearth = 0f;
            }
        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arson"))
        {
            
            timeSinceLastDamage = 0f;
        }

        if (collision.gameObject.CompareTag("hearth"))
        {
            
            timeSinceLastDamageHearth = 0f;
        }
    }


}
