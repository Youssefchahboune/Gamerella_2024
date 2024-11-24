using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;  // Position where enemies will spawn
    [SerializeField] private float minCooldown = 3f;  // Minimum cooldown in seconds
    [SerializeField] private float maxCooldown = 5f;  // Maximum cooldown in seconds
    [SerializeField] private GameObject enemyDropletPrefab;  // The enemy prefab to spawn

    private float currentCooldown;  // Track the current cooldown timer

    private AudioSource spawnSoundEffect;

    void Start()
    {
        // Set the initial random cooldown between minCooldown and maxCooldown
        SetRandomCooldown();

        spawnSoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;  // Reduce the cooldown by the time elapsed

        if (currentCooldown <= 0f)  // Check if the cooldown is over
        {
            // Instantiate the enemy at the spawn point
            Instantiate(enemyDropletPrefab, spawnPoint.position, Quaternion.identity);

            spawnSoundEffect.Play();

            // Set a new random cooldown for the next spawn
            SetRandomCooldown();
        }
    }

    // Method to set a random cooldown between minCooldown and maxCooldown
    void SetRandomCooldown()
    {
        currentCooldown = Random.Range(minCooldown, maxCooldown);
    }
}
