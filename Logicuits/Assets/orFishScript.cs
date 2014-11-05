using UnityEngine;
using System.Collections;

public class orFishScript : MonoBehaviour {


	public const float HORIZONTAL_UPPER_LIMIT=4.8f;
	public const float HORIZONTAL_BOTTOM_LIMIT=-2f;
	public const float VERTICAL_UPPER_LIMIT = -1f;
	public const float VERTICAL_BOTTOM_LIMIT = 2.3f;

	public const float VELOCITY_MODULE = 10.0f; 

	// Use this for initialization
	void Start () { 
		rigidbody2D.velocity = generateRandomVelocity (true,true);


	}
	
	// Update is called once per frame
	void Update () {

		float current_fish_x = rigidbody2D.position.x;
		float current_fish_y = rigidbody2D.position.y;


		if (current_fish_x >= HORIZONTAL_UPPER_LIMIT && current_fish_y <= VERTICAL_UPPER_LIMIT) {
 

						print ("HU " + current_fish_x + ",VU" + current_fish_y);
						rigidbody2D.velocity = generateRandomVelocity (false, false);

				} else if (current_fish_x >= HORIZONTAL_UPPER_LIMIT && current_fish_y >= VERTICAL_BOTTOM_LIMIT) {

						print ("HU " + current_fish_x + ",VB" + current_fish_y);
						rigidbody2D.velocity = generateRandomVelocity (false, true);
				}

		else if (current_fish_x <= HORIZONTAL_BOTTOM_LIMIT && current_fish_y <= VERTICAL_UPPER_LIMIT) {
 

				print ("HB "+current_fish_x+",VU"+current_fish_y);
				rigidbody2D.velocity = generateRandomVelocity (true,false);

		} else if(current_fish_x <= HORIZONTAL_BOTTOM_LIMIT && current_fish_y >= VERTICAL_BOTTOM_LIMIT) {

				print ("HB "+current_fish_x+",VB"+current_fish_y);
				rigidbody2D.velocity = generateRandomVelocity (true,true);
			}
 
		}



	Vector2 generateRandomVelocity(bool x_upwards, bool y_upwards){
		float x = VELOCITY_MODULE * Random.value;
		float y = VELOCITY_MODULE * Random.value;

		if (!x_upwards) {
			x *= -1;
				}
		//y-axis is inverted in computers
		if (y_upwards) {
			y *=-1;
				}


		Vector2 ret = new Vector2 (x, y);
		return ret;
	}
}
