using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerFPS : MonoBehaviour {
	private int maxFps = 20;

	private void Start() {
		Application.targetFrameRate = maxFps;
		QualitySettings.vSyncCount = 0;
	}

	private void Update() {
		if (Application.targetFrameRate != maxFps) {
			Application.targetFrameRate = maxFps;
		}
	}
}
