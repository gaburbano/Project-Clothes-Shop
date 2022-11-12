using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rigidbody2D;
    public Animator animator;

    private Vector2 movement;
    
    public Vector2 lastMotionVector;
    
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        lastMotionVector = new Vector2(
            movement.x,
            movement.y
        ).normalized;
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
