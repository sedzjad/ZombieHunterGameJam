using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
	private Zombie _zombie;
    private bool movingLeft = true;

    public float speed;
	private int randomInt;
	public bool isDead = false;
    public Transform groundDetection;

	private void Start() {
		_zombie = FindObjectOfType<Zombie>();
		_zombie.ZombieDied += Dying;
		randomInt = Random.Range(1, 3);

		// Randomize moving direction on spawn.
		if (randomInt == 1) {
			transform.eulerAngles = new Vector3(0, -180, 0);
			movingLeft = true;
		} else {
			transform.eulerAngles = new Vector3(0, 0, 0);
			movingLeft = false;
		}
	}

	void Update()
    {
        if (isDead) { // Stop moving if zombie is shot.
			transform.position = transform.position;
		}

		if (!isDead) { // While alive, keep moving.
			transform.Translate(Vector2.left * speed * Time.deltaTime);
			// Check to see if zombie is near boundaries of the game. If so, turn the other way.
			RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
			if (groundInfo.collider == false) {
				if (movingLeft == true) {
					transform.eulerAngles = new Vector3(0, 0, 0);
					movingLeft = false;
				} else {
					transform.eulerAngles = new Vector3(0, -180, 0);
					movingLeft = true;
				}
			}
		}
	}

	private void Dying(float x) {
		isDead = true;
	}
}
