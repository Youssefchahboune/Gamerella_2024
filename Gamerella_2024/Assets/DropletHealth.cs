using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletHealth : MonoBehaviour
{
    private int enemyHealth;
    public int enemyPoint = 100;
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
                GlobalVariables.updateScore(enemyPoint);

                Destroy(gameObject);
            }
        }
    }
}
