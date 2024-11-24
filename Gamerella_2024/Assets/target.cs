using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Transform target1; // First target to follow
    private Transform target2; // Second target to follow
    public float speed;  // Movement speed of the enemy

    private Transform currentTarget; // The current target being followed
    
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D attached to this GameObject!");
            return;
        }


        GameObject target1Object = GameObject.Find("Arson");
        GameObject target2Object = GameObject.Find("Hearth");

        if (target1Object != null) target1 = target1Object.transform;
        if (target2Object != null) target2 = target2Object.transform;

        if (target1 == null || target2 == null)
        {
            Debug.LogWarning("One or both targets could not be found. Ensure the correct tags are assigned.");
        }

        System.Random r = new System.Random();
        speed = r.Next(2, 5);

        
    }

    void FixedUpdate() // Use FixedUpdate for physics updates
    {
        if (rb == null || target1 == null || target2 == null) return;

        // Determine which target is closer
        float distanceToTarget1 = Vector2.Distance(transform.position, target1.position);
        float distanceToTarget2 = Vector2.Distance(transform.position, target2.position);

        currentTarget = (distanceToTarget1 < distanceToTarget2) ? target1 : target2;

        // Move towards the current target
        if (currentTarget != null)
        {
            Vector2 direction = (currentTarget.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // Flip scale to face the target
            Vector3 scale = transform.localScale;
            scale.x = (currentTarget.position.x > transform.position.x) ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            // Stop the Rigidbody if there's no target
            rb.velocity = Vector2.zero;
        }
    }
}
