using UnityEngine;

public class ThirdPersonPlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 7f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isOnGround;

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is on the ground
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the player "stacks up" velocity in the y axis from acceleration due to gravity then when the player leaves the ground they will start moving downwards rapidly instead of starting at 0m/s and accelerating from there
        if (isOnGround && velocity.y < 0)
        {
            // This is being set to "-2" instead of "0" because the player may be considered on the ground even if they are slightly above it
            velocity.y = -2f;
        }

        // Get player's input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // The player's definition of forward/backward and right/left needs to be based on the rotation of the player
        Vector3 xMovement = transform.right * xInput * speed;
        Vector3 zMovement = transform.forward * zInput * speed;

        // flatVel refers to the velocity without taking into consideration the y axis due to gravity or jumping (the y property is constantly 0)
        Vector3 flatVel = xMovement + zMovement;

        // The flatVel is clamped so moving diagonally does not have an increased speed compared to moving in a single direction
        flatVel = Vector3.ClampMagnitude(flatVel, speed);

        velocity = new Vector3(flatVel.x, velocity.y, flatVel.z);

        // Account for jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            // Calculating velocity based on the maximum height we want the player to jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        // Note that the gravity constant is multiplied by Time.deltaTime again despite the velocity already being multiplied by Time.deltaTime in the CharacterController.Move method
        // This is because gravity is an acceleration (m/s^2) instead of a velocity (m/s)
        velocity.y += gravity * Time.deltaTime;

        // Move the player
        characterController.Move(velocity * Time.deltaTime);
    }
}
