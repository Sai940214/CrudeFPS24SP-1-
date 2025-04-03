using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float walkingSpeed = 5f;
    [SerializeField] float runningSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = -9.81f;

    [SerializeField] Transform spawningPoint;

    [SerializeField] Transform head;

    [SerializeField] FlashLight FlashLight;

    float xRotation; // remember head rotation
    Vector3 velocity; // remember player speed (needed for falling)

    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Deal with mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // === MOVING ===
        // Read controller inputs (WASD etc)
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = (transform.right * moveHorizontal
                         + transform.forward * moveVertical).normalized;

        //set movement speed
        float speed = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else
        { 
            speed = walkingSpeed;
        }

        // === MOUSE LOOK ===
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Look up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 65f);
        head.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Turn
        transform.Rotate(Vector3.up * mouseX);

        // === GRAVITY & JUMPING ===

        // If we are standing on ground, reset velocity.y
        if (controller.isGrounded && velocity.y <0)
        {
            velocity.y = -2f; // clamp feet to the ground
        }

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply pull of gravity every frame
        velocity.y += gravity * Time.deltaTime;

        // Apply movement
        controller.Move((movement * speed + velocity) * Time.deltaTime);

        // === TOGGLE FLASHLIGHT ===
        if (Input.GetMouseButtonDown(0))
        {
            FlashLight.ToggleFlashlight();
        }
    }

    public void ResetBacktoSpawningPoint()
    {
        controller.enabled = false;
        transform.position = spawningPoint.position;  
        controller.enabled = true;
    }
}
