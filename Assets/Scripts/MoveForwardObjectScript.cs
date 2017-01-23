using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardObjectScript : MonoBehaviour {

	private Transform objectTransform = null;
	private Transform objectToFollow = null;
	private bool moving = true;

	public float maxSpeed = 5.0f;
	public string tag = "Player";

	void Awake() {
		objectTransform = GetComponent<Transform> ();
		GameObject objectWithTag = GameObject.FindGameObjectWithTag(tag);
		if (objectWithTag != null) {
			objectToFollow = objectWithTag.GetComponent<Transform> ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (objectToFollow == null) {
			return;
		}

		if (moving) {
			Vector3 objectPosition = objectTransform.position;
			Vector3 objectToFollowPosition = objectToFollow.position;
			objectToFollowPosition.x -= objectPosition.x;
			objectToFollowPosition.y -= objectPosition.y;

			//First rotate towards the object
			float angle = Mathf.Atan2 (objectToFollowPosition.y, objectToFollowPosition.x) * Mathf.Rad2Deg;
			objectTransform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);


		}
		//Second move
		objectTransform.position += objectTransform.right * maxSpeed * Time.deltaTime;
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == tag) {
			moving = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == tag) {
			moving = true;
		}
	}
}
