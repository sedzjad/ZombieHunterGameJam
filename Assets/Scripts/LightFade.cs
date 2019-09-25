using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour {
	// Timers.
	// Values.
	private float minAlpha = 0;
	private float maxAlpha = 255;
	private bool direction = false;
	private float speed = 0.4f;
	// Components.
	public GameObject go;
	private SpriteRenderer sr;

	private void Start() {
		sr = go.GetComponent<SpriteRenderer>();
	}

	private void Update() {
		// Change opacity.
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, minAlpha);
		
		if (minAlpha >= 1) {
			direction = true;
		}
		if (minAlpha <= 0) {
			direction = false;
		}

		if (direction) {
			minAlpha -= speed * Time.deltaTime;
		}

		if (!direction) {
			minAlpha += speed * Time.deltaTime;
		}
	}
}
