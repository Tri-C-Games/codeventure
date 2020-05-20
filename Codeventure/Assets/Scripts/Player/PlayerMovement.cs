using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    // Input variables
    private float hor;
    private float ver;

    // The velocity after parsing input
    private Vector3 newVel;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Grab all inputs
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        // Setting the new velocity that is the inputs multiplied by speed
        // The movement vector is clamped as to keep the speed the same regardless of if the player is travelling diagonally or not
        newVel = Vector2.ClampMagnitude(new Vector2(hor, ver), 1) * speed;

        // Applying the new velocity
        rb.velocity = newVel;
    }
}