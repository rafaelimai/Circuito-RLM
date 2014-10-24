using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {

	public GameObject startPoint;
	public GameObject endPoint;

	public int state;
	public float speed = 5f;

	bool done = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Path and state propagation
		if (!done) {
			if (endPoint.transform.position.x > startPoint.transform.position.x) {
				if (transform.position.x < (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = new Vector3 (speed,0f,0f);
				}
				else if (transform.position.x < (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
					rigidbody2D.velocity = speed*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
				}
				if (transform.position.x > (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = new Vector3 (speed,0f,0f);
				}
				if (transform.position.x > endPoint.transform.position.x) {
					endPoint.GetComponent<StatePoint>().state = state;
					endPoint.GetComponent<StatePoint>().PropagateState(endPoint);
					rigidbody2D.velocity = new Vector3 (0f,0f,0f);
					transform.position = endPoint.transform.position;
					done = true;
				}
			}

			else {
				if (transform.position.x > (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = new Vector3 (-speed,0f,0f);
				}
				else if (transform.position.x > (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
					rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
					rigidbody2D.velocity = speed*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
				}
				if (transform.position.x < (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
					rigidbody2D.velocity = new Vector3 (-speed,0f,0f);
				}
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
