using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class destroy : MonoBehaviour {
	public Text scoreText;
	public int score;
	// Use this for initialization
	void Start () {
		print("start in destroy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		GameControll gameScript = GameObject.Find ("GameController").GetComponent<GameControll>();
		gameScript.score += 1;
		Destroy (other.gameObject);
		

	}
}
