﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControll : MonoBehaviour {
	public Camera cam;
	public GameObject fall;
	//public GameObject fall2;
	//public GameObject fall3;
	private float maxWidth;
	public Text scoreText;
	public float score;
	public GameObject[] myObjects;
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector2 (Screen.width, Screen.height);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		//fall = GameObject.Find ("fall");
		StartCoroutine (Spawn ());
		score = 0;
        myObjects =  new GameObject[3];
		myObjects[0] = fall;
	//	myObjects[1] = fall2;
	//	myObjects[2] = fall3;
	}

	void FixedUpdate() {

		//score += Time.deltaTime;
		scoreText.text = "Score\n" + Mathf.RoundToInt (score);
		//print ("score = " + score);
	}

	IEnumerator Spawn() {
		yield return new WaitForSeconds (2.0f);
		while (true) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.localPosition.y, 0);
			Quaternion spawnRotation = Quaternion.identity;
	//		Instantiate (myObjects[Random.Range (0,3)], spawnPosition, spawnRotation);
			Instantiate (myObjects[0], spawnPosition, spawnRotation);
	//		Instantiate (fall2, spawnPosition, spawnRotation);
	//		Instantiate (fall3, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
		}
	}

}
