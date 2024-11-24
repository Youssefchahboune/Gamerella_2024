using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletHealth : MonoBehaviour
{
    private int enemyHealth;
    public ParticleSystem explosingEffect;

    void Start()
    {
        enemyHealth = UnityEngine.Random.Range(1, 2);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            
            enemyHealth = enemyHealth - 1;

            if (enemyHealth <= 0)
            {
                

                GlobalVariables.updateScore(100);
                
                
                Instantiate(explosingEffect, transform.position, Quaternion.identity);
                    

                GlobalVariables.UpdateNumberOfDropletsKilled();

                //Debug.Log(GlobalVariables.numberOFDropletKilled);

                Destroy(gameObject);
            }
        }
    }
}
