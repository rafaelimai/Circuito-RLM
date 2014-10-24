using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {

	public GameObject startPoint;
	public GameObject endPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endPoint.transform.position.x > startPoint.transform.position.x) {
			if (transform.position.x < (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = new Vector3 (2f,0f,0f);
			}
			else if (transform.position.x < (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
				rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
				rigidbody2D.velocity = 2f*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
			}
			if (transform.position.x > (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = new Vector3 (2f,0f,0f);
			}
		}

		else {
			if (transform.position.x > (2f/3f*startPoint.transform.position.x + 1f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = new Vector3 (-2f,0f,0f);
			}
			else if (transform.position.x > (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = endPoint.transform.position - startPoint.transform.position;
				rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, 3f*rigidbody2D.velocity.y, 0f);
				rigidbody2D.velocity = 2f*rigidbody2D.velocity/rigidbody2D.velocity.magnitude;
			}
			if (transform.position.x < (1f/3f*startPoint.transform.position.x + 2f/3f*endPoint.transform.position.x)) {
				rigidbody2D.velocity = new Vector3 (-2f,0f,0f);
			}
		}
	}
}
