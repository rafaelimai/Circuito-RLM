using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {

	public GameObject startPoint;
	public GameObject endPoint;

	public int state;
	public float speed = 10f;

	public bool first;
	public bool second;
	public bool third;
	bool done;

	// Use this for initialization
	void Start () {
		first = false;
		second = false;
		third = false;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Path and state propagation
		if (!done) {
			if (endPoint.transform.position.x > startPoint.transform.position.x) {

				// If spark is entering the first part
				if (!first) {
					transform.position = startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (speed,0f,0f);
					first = true;
				}

				// If spark is entering the second part
				if (!second && transform.position.x > (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
					transform.position = new Vector3(2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x, transform.position.y, 0);
					rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
					rigidbody2D.velocity = speed*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
					second = true;
				}

				// If spark is in the third part
				if (!third && transform.position.x > (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					transform.position = new Vector3(1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x, endPoint.transform.position.y, 0);
					rigidbody2D.velocity = new Vector3 (speed,0f,0f);
					third = true;
				}

				// 
				if (transform.position.x > endPoint.transform.position.x) {
					endPoint.GetComponent<StatePoint>().state = state;
					endPoint.GetComponent<StatePoint>().PropagateState(endPoint);
					rigidbody2D.velocity = new Vector3 (0f,0f,0f);
					transform.position = endPoint.transform.position;
					done = true;
				}
			}

			else {
				
				// If spark is entering the first part
				if (!first && transform.position.x < startPoint.transform.position.x) {
					transform.position = startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (-speed,0f,0f);
					first = true;
				}
				
				// If spark is entering the second part
				if (!second && transform.position.x < (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
					transform.position = new Vector3(2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x, transform.position.y, 0);
					rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
					rigidbody2D.velocity = speed*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
					second = true;
				}
				
				// If spark is in the third part
				if (!third && transform.position.x < (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					transform.position = new Vector3(1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x, endPoint.transform.position.y, 0);
					rigidbody2D.velocity = new Vector3 (-speed,0f,0f);
					third = true;
				}
				
				// 
				if (transform.position.x < endPoint.transform.position.x) {
					endPoint.GetComponent<StatePoint>().state = state;
					endPoint.GetComponent<StatePoint>().PropagateState(endPoint);
					rigidbody2D.velocity = new Vector3 (0f,0f,0f);
					transform.position = endPoint.transform.position;
					done = true;
				}
			}

			// Color based on state
			if (state == 0) {
				GetComponent<SpriteRenderer>().color = Color.black;
			}
			if (state == 1) {
				GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}	
}
