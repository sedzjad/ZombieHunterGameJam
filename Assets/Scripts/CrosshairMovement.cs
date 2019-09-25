using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrosshairMovement : MonoBehaviour {
	// Components.
	private GameObject crosshair;
	private Rigidbody2D rb;
	private Shoot shoot;

	// Position.
	private Vector2 pos;

	// Movement.
	private Vector2 movement;
	private float horizontalMove, verticalMove;
	private float speed = 3;

	public void Start() {
		rb = GetComponent<Rigidbody2D>();
		shoot = FindObjectOfType<Shoot>();
		//shoot.
		crosshair = gameObject;
	}

	private void Update() {
	
	}

	private void FixedUpdate() {
		horizontalMove = Input.GetAxis("Horizontal") * speed;
		verticalMove = Input.GetAxis("Vertical") * speed;
		movement = new Vector2(horizontalMove, verticalMove);
		rb.velocity = movement;
	}
}
