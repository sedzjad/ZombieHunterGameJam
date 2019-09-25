using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score_Text : MonoBehaviour {
	private float score = 0;
	private float zombieKill = 50;
	private Text scoreText;

	private void Start() {
		scoreText = GameObject.Find("Score_Text").GetComponent<Text>();
	}

	// Increase score multiplied by multiplier from Shoot.
	public void IncreaseScore(float x) {
		score += zombieKill * x;
		scoreText.text = "SCORE: " + score.ToString();
	}
}
