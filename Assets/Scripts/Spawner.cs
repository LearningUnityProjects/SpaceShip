using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float initTime = 0.0f;
	public float spawnInterval = 2.0f;
	public GameObject spawnObject;

	private Vector3 centerPosition;

	//Screen limits
	private float verticalLimit;
	private float horizontalLimit;

	void Awake() {
		centerPosition = Camera.main.gameObject.transform.position;
	}

	void Start () {
		verticalLimit = Camera.main.orthographicSize;   
		horizontalLimit = verticalLimit * Screen.width / Screen.height;
		InvokeRepeating ("Spawn", initTime, spawnInterval);
	}

	void Spawn() {
		float radius = (verticalLimit > horizontalLimit) ? verticalLimit : horizontalLimit; 

		Vector3 spawnPosition = centerPosition + Random.onUnitSphere * radius;
		spawnPosition.x = (Mathf.Abs (spawnPosition.x) < horizontalLimit) ? addOffset (spawnPosition.x, horizontalLimit) : spawnPosition.x;
		spawnPosition.y = (Mathf.Abs (spawnPosition.y) < verticalLimit) ? addOffset (spawnPosition.y, verticalLimit) : spawnPosition.y;
		spawnPosition.z = 0.0f;
		Instantiate (spawnObject, spawnPosition, spawnObject.transform.rotation);
	}

	float addOffset(float originalPosition, float offset) {
		return (originalPosition > 0) ? originalPosition + offset : originalPosition - offset;
	}

}
