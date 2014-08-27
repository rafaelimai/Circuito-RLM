#pragma strict

var speed: float;

function Start () {
	rigidbody2D.velocity.x = speed;
}

function Update () {

	if (transform.position.x < -13.5) {
		transform.position.x += 27;
	
	}

}