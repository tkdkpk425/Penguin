﻿using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Screen.SetResolution(1080, 1920, true);
        Screen.orientation = ScreenOrientation.Portrait;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
