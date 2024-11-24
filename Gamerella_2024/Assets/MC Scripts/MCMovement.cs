using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator animator;
    private AudioSource audioSource;
    private bool walkingSoundPlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (animator != null)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsMoving", true);
                
                if(!walkingSoundPlaying) {
                    audioSource.Play();
                    walkingSoundPlaying = true;
                }
                
            }
            else
            {
                animator.SetBool("IsMoving", false);
                walkingSoundPlaying = false;
                audioSource.Stop();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
