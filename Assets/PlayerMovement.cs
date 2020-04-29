using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Camera cam;

    GameObject oldInteractableObject;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueSystem.Instance.isInDialogue)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (!DialogueSystem.Instance.isInDialogue)
            {
                HandleInteraction();
            }
        }
        
    }

    private void HandleInteraction()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5))
        {
            GameObject interactedObject = hit.collider.gameObject;

            if (oldInteractableObject != null && interactedObject != oldInteractableObject)
            {
                if (oldInteractableObject.tag == "Interactable Object")
                {
                    oldInteractableObject.GetComponent<Interactable>().DisplayEngage(false);
                }
            }
            else if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().DisplayEngage(true);
            }

            oldInteractableObject = interactedObject;

            if (interactedObject.tag == "Interactable Object" && Input.GetKeyDown(KeyCode.E))
            {
                interactedObject.GetComponent<Interactable>().Interact();
            }
        } else
        {
            // Remove panel of old object where the object is displayed
            if (oldInteractableObject != null && oldInteractableObject.tag == "Interactable Object")
            {
                oldInteractableObject.GetComponent<Interactable>().DisplayEngage(false);
            }
        }
    }
}
