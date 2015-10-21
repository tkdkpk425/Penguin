using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void startGame() {
		Application.LoadLevel ("penguin");
	}

	public void onClick() {
		startGame ();
	}

}
