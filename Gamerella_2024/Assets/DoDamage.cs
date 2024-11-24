using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 10; 
    public float damageInterval = 3f;
    public int hearthDamage = 5;
    
    public float hearthdamageInterval = 3f;
    private float timeSinceLastDamageHearth = 0f;

    private float timeSinceLastDamage = 0f;  // Timer to track time since the last damage

    void Start()
    {
        // Optionally initialize any variables here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arson"))
        {
            GlobalVariables.SetArsonHealth(damage);
        }

        if (collision.gameObject.CompareTag("hearth"))
        {
            GlobalVariables.SetHearthHealth(hearthDamage);
        }

    }
    private void OnCollisionStay2D(Collision2D collision) {
        // Check if the object colliding is the player (or with a tag like "arson")
        if (collision.gameObject.CompareTag("arson"))
        {

            // Increment the timer by the time that passed since the last frame
            timeSinceLastDamage += Time.deltaTime;

            // If the player is still touching and enough time has passed, deal damage
            if (timeSinceLastDamage >= damageInterval)
            {
                // Deal damage to the player's health
                GlobalVariables.SetArsonHealth(damage);

                // Reset the timer after dealing damage
                timeSinceLastDamage = 0f;
            }
        }

        if (collision.gameObject.CompareTag("hearth"))
        {

            // Increment the timer by the time that passed since the last frame
            timeSinceLastDamageHearth += Time.deltaTime;

            // If the player is still touching and enough time has passed, deal damage
            if (timeSinceLastDamageHearth >= hearthdamageInterval)
            {
                // Deal damage to the player's health
                GlobalVariables.SetHearthHealth(hearthDamage);

                // Reset the timer after dealing damage
                timeSinceLastDamageHearth = 0f;
            }
        }
    }

    // Optionally, reset the timer if the collision ends (when the player leaves the enemy)
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("arson"))
        {
            // Reset the timer when the player is no longer colliding
            timeSinceLastDamage = 0f;
        }

        if (collision.gameObject.CompareTag("hearth"))
        {
            // Reset the timer when the player is no longer colliding
            timeSinceLastDamageHearth = 0f;
        }
    }


}
