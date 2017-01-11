using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

	public float timeUntilDestroy = 2.0f;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy", timeUntilDestroy);
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
