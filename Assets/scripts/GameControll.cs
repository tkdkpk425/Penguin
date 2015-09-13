using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControll : MonoBehaviour {
	public Camera cam;
	public GameObject fall;
	private float maxWidth;
	public Text scoreText;
	public float score;
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
			Instantiate (fall, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
		}
	}
}
