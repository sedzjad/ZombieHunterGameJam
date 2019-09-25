using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoCrate : MonoBehaviour {
	private Shoot _shoot;

	public bool inRange = false;
	public bool isDead = false;

	private void Start() {
		_shoot = FindObjectOfType<Shoot>();
		_shoot.ShootPos += CrateDead;
	}

	private void CrateDead(Vector2 xhairPos) { // Compare crate location to crosshair location.
		if (!isDead) {
			float dist = Vector3.Distance(gameObject.transform.position, xhairPos);
			if (dist <= 0.5f) {
				isDead = true;
				_shoot.AmmoPickup();
				Destroy(gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			inRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Player") {
			inRange = false;
		}
	}
}
