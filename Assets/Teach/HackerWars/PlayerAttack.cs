﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Transform spawnTran;
	public GameObject bullet;
	private float touchTime = 0.0f;

	private bool canShot = true;

	void Update () {
		if (Input.touchCount > 0) {
			touchTime += Time.deltaTime;
			if (Input.touchCount == 1) {
				if (canShot) {
					ShotBullet ();
				}
			}
		} else {
			touchTime = 0;
			if (canShot == false) {
				canShot = true;
			}
		}
	}

	void ShotBullet(){
		Instantiate (bullet, spawnTran.position, spawnTran.rotation);
		canShot = false;
	}
}