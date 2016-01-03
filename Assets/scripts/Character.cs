using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	private int charcterNum;
	private float speed;
	private int size;
	private string description;
	public GameObject obj;
	public readonly int Penguin = 0;
	public readonly int Fox = 1;
	public readonly int Walarus = 2;
	public readonly int CharHolder = 3;
	public readonly int CharHolder2 = 4;

	// Use this for initialization
	void Start () {
//		obj = new GameObject ();
//		obj.AddComponent<Canvas> ();		
//		Canvas canvas = obj.GetComponent<Canvas> ();
//		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
//		canvas.AddComponenet<Text> ();
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getSpeed() {
		return speed;
	}

	public void setSpeed(float speed) {
		this.speed = speed;
	}

	public int getSize() {
		return size;
	}

	public void setSize(int size) {
		this.size = size;
	}

	public string getDescription() {
		return description;
	}

	public void setCharacterNum(int num) {
		this.charcterNum = num;
	}

	public int getCharacterNum() {
		return charcterNum;
	}
}
