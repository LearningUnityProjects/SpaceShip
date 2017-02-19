using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//Game score
	public static int score;

	//Prefix
	public string scorePrefix = string.Empty;

	public Text scoreText = null;

	public Text gameOverText = null;

	public static GameController instance = null;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreText != null) {
			scoreText.text = scorePrefix + score.ToString();
		}
	}

	public static void GameOver() {
		if (instance.gameOverText != null) {
			instance.gameOverText.gameObject.SetActive (true);
		}
	}
}
