using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

	private Rigidbody2D shipRigidbody;
	private Transform shipTransform;

	public float maxSpeed = 5.0f;

	void Awake() {
		shipRigidbody = GetComponent<Rigidbody2D> ();
		shipTransform = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//If you want to control an object through the physics system, you should use FixedUpdate
	void FixedUpdate ()
	{
		//Update movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector2 moveDirection = new Vector2(horizontal, vertical);

		shipRigidbody.AddForce (moveDirection * maxSpeed);

		//Clamp speed
		shipRigidbody.velocity = new Vector2(Mathf.Clamp(shipRigidbody.velocity.x, -maxSpeed, maxSpeed),
			Mathf.Clamp(shipRigidbody.velocity.y, -maxSpeed, maxSpeed));

		//Get mouse position
		Vector3 mousePosition = Input.mousePosition;
		//Calculate distance from camera to ship
		mousePosition.z = Camera.main.transform.position.z - shipTransform.position.z;

		Vector3 objectPosition = Camera.main.WorldToScreenPoint(shipTransform.position);
		mousePosition.x = mousePosition.x - objectPosition.x;
		mousePosition.y = mousePosition.y - objectPosition.y;

		//Get the angle from the ship to the mouse pointer
		float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
		shipTransform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);
	}
		
}
