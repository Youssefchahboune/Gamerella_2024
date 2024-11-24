using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int enemyHealth;
    void Start()
    {
        System.Random rand = new System.Random();
        enemyHealth = rand.Next(2,4);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            enemyHealth=enemyHealth-1;

            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
