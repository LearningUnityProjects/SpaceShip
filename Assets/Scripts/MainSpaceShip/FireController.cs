using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	public string fireAxis = "Fire1";
	public float reloadDelay = 0.3f;
	public bool canFire = true;

	public Transform[] turretTransforms;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetButtonDown(fireAxis) && canFire)
		{
			foreach (Transform t in turretTransforms) {
				AmmoManager.SpawnAmmo (t.position, t.rotation);
			}

			canFire = false;
			Invoke ("EnableFire", reloadDelay);
		}
	}

	void EnableFire()
	{
		canFire = true;
	}
}
