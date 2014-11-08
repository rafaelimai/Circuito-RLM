using UnityEngine;
using System.Collections;

public class ConveyorScript : MonoBehaviour {

	// Use this for initialization

	public const float VELOCITY_MODULE = 0.5f;
	public const float HORIZONTAL_UPPER_LIMIT= -3.45f;
	public Vector2 up_none = new Vector2 (VELOCITY_MODULE, 0f);

	void Start () {
		rigidbody2D.velocity = new Vector2 (VELOCITY_MODULE, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D.position.x + VELOCITY_MODULE*Time.deltaTime >= HORIZONTAL_UPPER_LIMIT) {

			rigidbody2D.position = new Vector2 (-4.055f, rigidbody2D.position.y);


		}

	}
}
