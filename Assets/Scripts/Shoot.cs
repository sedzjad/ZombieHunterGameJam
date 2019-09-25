using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour{
	// Timers.
	private float betweenShotTime = 0.3f;
	private float reloadTime = 1f;
	public float reloadTimer = 0;
	private bool reloading = false;

	// Actions.
	public Action<int> Shooting;
	public Action<Vector2> ShootPos;

	// Values.
	private int currentAmmoValue;
	private int ammoValue = 6;

	private void Start() {
		currentAmmoValue = ammoValue;
		if (Shooting != null) {
			Shooting(currentAmmoValue);
		}
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && !reloading && ammoValue != 0 ||
			Input.GetButtonDown("Fire1") && !reloading && ammoValue != 0) {
			currentAmmoValue--;
			reloading = true;
			if (Shooting != null) {
				Shooting(currentAmmoValue);
			}
			if (ShootPos != null) {
				ShootPos(gameObject.transform.position);
			}
		}

		// Reload timer.
		if (reloading && currentAmmoValue == 0) {
			reloadTimer += Time.deltaTime;
			if (reloadTimer >= reloadTime) {
				reloading = false;
				if (Shooting != null) {
					Shooting(currentAmmoValue);
				}
				reloadTimer = 0;
				currentAmmoValue = ammoValue;
			}
		}

		// Between the shots timer.
		if (reloading && currentAmmoValue != 0) {
			reloadTimer += Time.deltaTime;
			if (reloadTimer >= betweenShotTime) {
				reloading = false;
				reloadTimer = 0;
				if (Shooting != null) {
					Shooting(currentAmmoValue);
				}
			}
		}
	}

	public void AmmoPickup() {
		currentAmmoValue += 4;
	}
}
