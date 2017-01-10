using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour {
	
	private Transform shipTransform;
	private Collider2D shipCollider;

	private float verticalLimit;
	private float horizontalLimit;

	void Awake() {
		shipTransform = GetComponent<Transform> ();
		shipCollider = GetComponent<Collider2D> ();
	}

	// Use this for initialization
	void Start () {
		verticalLimit = Camera.main.orthographicSize;   
		horizontalLimit = (verticalLimit * Screen.width / Screen.height) - shipCollider.bounds.size.x/2;
		verticalLimit -= shipCollider.bounds.size.y / 2;
	}
	
	void LateUpdate () {
		//Clamp position
		shipTransform.position = new Vector3(Mathf.Clamp(shipTransform.position.x, -horizontalLimit, horizontalLimit),
			Mathf.Clamp(shipTransform.position.y, -verticalLimit, verticalLimit), 0.0f);
	}
}
