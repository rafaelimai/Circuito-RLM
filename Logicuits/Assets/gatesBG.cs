using UnityEngine;
using System.Collections;



public class gatesBG : MonoBehaviour {

	/* 
												 _    _  ___  ______ _   _ _____ _   _ _____ 
												| |  | |/ _ \ | ___ \ \ | |_   _| \ | |  __ \
												| |  | / /_\ \| |_/ /  \| | | | |  \| | |  \/
												| |/\| |  _  ||    /| . ` | | | | . ` | | __ 
												\  /\  / | | || |\ \| |\  |_| |_| |\  | |_\ \
												 \/  \/\_| |_/\_| \_\_| \_/\___/\_| \_/\____/
	 * 
	 * WARNING - Although x-axis orientation is kept as standard (from left to right), y-axis orientation is inverted
	 * in computer screens (instead of something like "bottom to top", it is oriented like "top to bottom").
	 * This is a standard among computers, as far as I know, and may cause many errors (own experience).
	 */


	// Module of the rigidBody velocity. Represented as a constant to make changes easier.
	// Also, for debug purposes, one should set this value to 10 or higher to avoid time wasting. Discovered this through the hard way LOL

	public const float VELOCITY_MODULE = 1f;

	//Those values need to be adjusted to the screen dimensions. They were measured experimentally (i.e, they rely on the current screen dimensions).
	//If there is a way to access the screen dimensions, it should be used here instead of those hard-coded values.
	//The values are stored in constants for the sake of comprehension and easiness of changes (if needed).

	public const float HORIZONTAL_UPPER_LIMIT=12f;
	public const float HORIZONTAL_BOTTOM_LIMIT=-12f;
	public const float VERTICAL_UPPER_LIMIT = 7f;
	public const float VERTICAL_BOTTOM_LIMIT = -7f;


	//Those vectors here intend to avoid creating multiple instances with the same values.
	//Their names are given based on their behavior; up and down represent, in this order, a raise or a decrease in the rigid body position.
	//The first word refers to the x-axis vector behaviour, and the second word to the y-axis vector behaviour.
	public Vector2 up_none = new Vector2 (VELOCITY_MODULE, 0f);
	public Vector2 down_none = new Vector2 (-VELOCITY_MODULE, 0f);
	public Vector2 none_down = new Vector2 (0f, VELOCITY_MODULE);
	public Vector2 none_up = new Vector2 (0f, -VELOCITY_MODULE);

	public Vector2 speed; 

	// Use this for initialization
	void Start () {

		rigidbody2D.velocity = down_none;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (rigidbody2D.position.y >= VERTICAL_UPPER_LIMIT ) {	
			if(rigidbody2D.position.x >= HORIZONTAL_UPPER_LIMIT){ 
				// UPPER RIGHT CORNER

				rigidbody2D.velocity = down_none; 


//				print ("down_none "+"Position (" + rigidbody2D.position.x + " , " + rigidbody2D.position.y + ")");


			}else if(rigidbody2D.position.x <= HORIZONTAL_BOTTOM_LIMIT){
				// UPPER LEFT CORNER
 
				rigidbody2D.velocity = none_up;


//				print ("none_up "+"Position (" + rigidbody2D.position.x + " , " + rigidbody2D.position.y + ")");

			}			
		} else if (rigidbody2D.position.y <= VERTICAL_BOTTOM_LIMIT){ 
			if(rigidbody2D.position.x >= HORIZONTAL_UPPER_LIMIT){ 
				// BOTTOM RIGHT CORNER
 
				rigidbody2D.velocity = none_down;


//				print ("none_down "+"Position (" + rigidbody2D.position.x + " , " + rigidbody2D.position.y + ")");

			}else if(rigidbody2D.position.x <= HORIZONTAL_BOTTOM_LIMIT){	
				// BOTTOM LEFT CORNER
 
				rigidbody2D.velocity =  up_none;


//				print ("up_none "+"Position (" + rigidbody2D.position.x + " , " + rigidbody2D.position.y + ")");
				
			}
		}


 
	}
}
