using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float _healthPoints = 100f;
	
	public GameObject deathParticlesPrefab = null;
	private Transform thisTransform = null;
	public bool shouldDestroyOnDeath = true;

	void Start() {
		thisTransform = GetComponent<Transform>();
	}

	public float HealthPoints {
		get {
			return _healthPoints;
		}

		set {
			_healthPoints = value;

			if(_healthPoints <= 0)
			{
				SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);

				if(deathParticlesPrefab != null)
					Instantiate(deathParticlesPrefab, thisTransform.position, thisTransform.rotation);

				if(shouldDestroyOnDeath)
					Destroy(gameObject);
			}
		}
	}


	//Only for test purpose
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
			HealthPoints = 0;
	}
}
