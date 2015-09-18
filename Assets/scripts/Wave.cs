using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public float scrollSpeed = -0.1f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;

    }
}
