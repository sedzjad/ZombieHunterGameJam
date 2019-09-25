using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playtime_Text : MonoBehaviour {
	private Text time;
	private Playtime _pt;

	private void Start() {
		time = GameObject.Find("Playtime_Text").GetComponent<Text>();
		_pt = FindObjectOfType<Playtime>();
		_pt.TimeAnnouncer += SetTimeText;
	}

	// Display time in HUD.
	private void SetTimeText(int x) {
		time.text = "TIME: " + x.ToString();
	}
}
