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

		if (horizontal != 0 || vertical != 0) {
			Debug.Log ("h: " + horizontal);
			Debug.Log ("v: " + vertical);
		}

	}
}
