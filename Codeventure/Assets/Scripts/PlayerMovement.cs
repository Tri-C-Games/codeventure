using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//the speed of the movement
	public float speed = 10f;

	//rigidbody: this controls all the physics
	private Rigidbody2D rb;
	//input variables
	private float hor;
	private float ver;
	//the velocity after parsing input
	private Vector3 newVel;

    // Start is called before the first frame update
    void Start()
    {
		//getting the component from the gameobject. It's like getting a child node in godot
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		//grab all inputs
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");

		//setting the new velocity that is the inputs multiplied by speed
		// The movement vector is normalized as to keep the speed the same regardless of if the player is travelling diagonally or not
		newVel = new Vector2(hor, ver).normalized * speed;

		//applying the new velocity
		rb.velocity = newVel;
    }
}
