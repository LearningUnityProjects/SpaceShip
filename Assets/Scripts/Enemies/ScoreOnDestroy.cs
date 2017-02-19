using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour {

	public int scoreValue = 50;

	void OnDestroy() {
		GameController.score += scoreValue;
	}
}
