using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : MonoBehaviour {
	private Shoot _shoot;
	private Animator anim;
	private ZombieArray _zarray;
	private Score_Text _scoreText;
	private bool isDead = false;

	public Action<float> ZombieDied;
	public GameObject headshotText;
	public bool inRange = false;

	// Point multiplier.
	private float bodyshot = 1f;
	private float headshot = 2.5f;
	private float multiplier = 0f;

	private void Start() {
		anim = GetComponentInChildren<Animator>();
		_shoot = FindObjectOfType<Shoot>();
		_scoreText = GameObject.Find("Score_Text").GetComponent<Score_Text>();
		_shoot.ShootPos += ZombieDead;
	}

	// If zombie is alive, compare distance between zombie and crosshair.
	private void ZombieDead(Vector2 xhairPos) {
		if (!isDead) {
			float dist = Vector3.Distance(gameObject.transform.position, xhairPos);
			// If within range, kill zombie.
			if (dist <= 0.5f) {
				_scoreText.IncreaseScore(multiplier);
				isDead = true;
				anim.Play("Death");
				// Announce zombie is dead, and if it was a headshot or not.
				if (ZombieDied != null) {
					ZombieDied(multiplier);
					// If it was a headshot, display the text.
					if (multiplier == headshot) {
						Instantiate(headshotText, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
					}
				}
				// Destroy the zombie, after death animation is done.
				Destroy(gameObject, 1f);
			}
		}
	}

	// Check to see if the shot was meant for this zombie by using colliders.
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			if (collision.transform.position.y > gameObject.transform.position.y + 0.2f) {
				multiplier = headshot;
			}
			if (collision.transform.position.y < gameObject.transform.position.y + 0.2f) {
				multiplier = bodyshot;
			}
			inRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Player") {
			inRange = false;
		}
	}
}
