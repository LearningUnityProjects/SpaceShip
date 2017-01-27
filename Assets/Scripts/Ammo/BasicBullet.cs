using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

	public float damage = 100.0f;
	public float lifeTime = 2.0f;

	void OnEnable()
	{
		CancelInvoke();
		Invoke("Die", lifeTime);
	}

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.gameObject.tag == "Enemy") {

			//Get health component
			Health H = Col.gameObject.GetComponent<Health> ();

			if (H == null)
				return;

			H.healthPoints -= damage;
			Die ();
		}
	}

	void Die()
	{
		gameObject.SetActive(false);
	}
}
