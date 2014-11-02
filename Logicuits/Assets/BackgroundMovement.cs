using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	// Use this for initialization

	public const float VELOCITY_MODULE = 0.7f;
	public Vector2 none_up = new Vector2 (0f,VELOCITY_MODULE);
	public Vector2 none_none = new Vector2 (0f, 0f);


	public const float VERTICAL_UPPER_LIMIT = 23.2f; 


	void Start () {
		rigidbody2D.velocity = none_up; 
	}
	
	// Update is called once per frame
	void Update () {
	 	if (rigidbody2D.position.y >= VERTICAL_UPPER_LIMIT) {

			rigidbody2D.velocity = none_none; 

		}
	 
	}
}
