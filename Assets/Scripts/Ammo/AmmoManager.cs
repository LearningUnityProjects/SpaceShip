using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {

	public GameObject ammo = null;
	public int poolSize = 50;

	public Queue<Transform> ammoQueue = new Queue<Transform> ();

	private GameObject[] ammoArray;

	public static AmmoManager singleton = null;

	// Use this for initialization
	void Awake () {
		if (singleton != null) {
			Destroy (GetComponent<AmmoManager> ());
			return;
		}
		singleton = this;
		ammoArray = new GameObject[poolSize];
		for(int i = 0; i < poolSize; i++) {
			ammoArray[i] = Instantiate(ammo, Vector3.zero, Quaternion.identity) as GameObject;
			Transform objTransform = ammoArray[i].GetComponent<Transform>();
			objTransform.parent = GetComponent<Transform>();
			ammoQueue.Enqueue(objTransform);
			ammoArray[i].SetActive(false);
		}
	}
	
	public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
	{
		//Get ammo
		Transform spawnedAmmo = singleton.ammoQueue.Dequeue();

		spawnedAmmo.gameObject.SetActive(true);
		spawnedAmmo.position = Position;
		spawnedAmmo.localRotation = Rotation;

		//Add to queue end
		singleton.ammoQueue.Enqueue(spawnedAmmo);

		//Return ammo
		return spawnedAmmo;
	}
}
