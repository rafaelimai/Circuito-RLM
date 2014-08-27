using UnityEngine;
using System.Collections;



public class gatesBG : MonoBehaviour {
	
	public Vector2 speed;
	public Vector2 start;

	// Use this for initialization
	void Start () {

		rigidbody2D.velocity = speed;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -13.5f) {
			start = transform.position;
			start.x += 27f;
			transform.position = start;
		}

	}
}
