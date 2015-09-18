using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuControl : MonoBehaviour {

	public Button startText;

	// Use this for initialization
	void Start () {
		startText = startText.GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Input.touchCount);
	if (Input.touches.Length > 0) {
			startLevel(1);
		}
	}

	public void startLevel(int level) {
		Application.LoadLevel (1);
	}
}
