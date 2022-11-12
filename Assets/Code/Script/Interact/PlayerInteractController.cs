using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerController playerController;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;
    private Player player;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }
    
    void Interact()
    {
        Vector2 position = rigidbody2D.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            Interactable hitInteractable = collider.GetComponent<Interactable>();
            if (hitInteractable != null)
            {
                hitInteractable.Interact(player);
                break;
            }
        }
    }
}
