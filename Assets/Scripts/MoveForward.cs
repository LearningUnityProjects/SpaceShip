using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = 2.0f;

	private Transform objectTransform = null;

	// Use this for initialization
	void Awake () {
		objectTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		objectTransform.position += objectTransform.right * maxSpeed * Time.deltaTime;
	}
}
