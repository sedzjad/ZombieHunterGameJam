using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Playtime : MonoBehaviour{
	//public float playTime = 0;
	public float playTime;
	private int duration;
	//public float announceTime = 0;
	private int announceInt = 0;
	private bool playing = true;

	// Actions.
	public Action<int> TimeAnnouncer;

    //UI panels.
    public GameObject GameTextPanel;

	void Update()
    {
		if (playing) {
			playTime -= Time.deltaTime;

			//if (announceTime % 60 <= 1) {
			//	announceTime += Time.deltaTime;
			//}

			//if (announceTime % 60 >= 1) {
			//	announceInt++;
			//	if (TimeAnnouncer != null) {
			//		TimeAnnouncer(announceInt);
			//	}
			//	announceTime = 0;
			//}
			announceInt = Mathf.FloorToInt(playTime) + duration;

			// Announce time for hud to display.
			if (TimeAnnouncer != null) {
				TimeAnnouncer(announceInt);
			}
		}

		if (announceInt <= 0) {
            // Game Over.
            SceneManager.LoadScene("GameOver");
		}
	}
}
