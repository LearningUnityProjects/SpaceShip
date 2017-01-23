using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour {

	public float damageRate = 10.0f;

	void OnTriggerStay2D(Collider2D coll) {
		Health health = coll.gameObject.GetComponent<Health> ();
		if (health != null) {
			health.healthPoints -= damageRate * Time.deltaTime;
		}
	}
}
