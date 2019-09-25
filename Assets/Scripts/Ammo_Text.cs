using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo_Text : MonoBehaviour {
	private Text ammo;
	private Shoot _shoot;

	private void Start() {
		ammo = GameObject.Find("Ammo_Text").GetComponent<Text>();
		_shoot = FindObjectOfType<Shoot>();
		_shoot.Shooting += SetAmmoText;
	}

	private void SetAmmoText(int x) {
		ammo.text = "AMMO: " + x.ToString();
	}
}
