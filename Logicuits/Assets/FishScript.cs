using UnityEngine;
using System.Collections;

public class FishScript : MonoBehaviour {


	public const float HORIZONTAL_UPPER_LIMIT = 8.0f;
	public const float HORIZONTAL_BOTTOM_LIMIT = 1.2f;
	public const float VERTICAL_UPPER_LIMIT = 0.6f;
	public const float VERTICAL_BOTTOM_LIMIT = 3.9f;
	public float SCALE_MODULE;
	public const float VELOCITY_MODULE = 0.5f; 

	// Use this for initialization
	void Start () { 
		rigidbody2D.velocity = generateRandomVelocity (true,true);
		SCALE_MODULE = rigidbody2D.transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {

				float current_fish_x = rigidbody2D.position.x;
				float current_fish_y = rigidbody2D.position.y;
				Vector2 currentVelocity = rigidbody2D.velocity;
				Vector2 newVelocity;
				


				if (current_fish_x >= HORIZONTAL_UPPER_LIMIT) {						
					currentVelocity = renewVelocity(currentVelocity,true,false);
			rigidbody2D.transform.localScale = new Vector3(-SCALE_MODULE,SCALE_MODULE,1);
					
				} else if (current_fish_x <= HORIZONTAL_BOTTOM_LIMIT) {
					currentVelocity = renewVelocity(currentVelocity,true,true);
			rigidbody2D.transform.localScale = new Vector3(SCALE_MODULE,SCALE_MODULE,1);

				} 
		
				if (current_fish_y <= VERTICAL_UPPER_LIMIT) {
					currentVelocity	= renewVelocity(currentVelocity,false,true); 
				} else if (current_fish_y >= VERTICAL_BOTTOM_LIMIT) {
					currentVelocity = renewVelocity(currentVelocity,false,false);	 
				}
				
		rigidbody2D.velocity = currentVelocity;
				

		}

	Vector2 renewVelocity(Vector2 oldVelocity, bool changeX, bool increase){

		float oldY = oldVelocity.y;
		float oldX = oldVelocity.x;
		Vector2 newSpeed; 

		if (changeX) {
				
			newSpeed = new Vector2(generateRandomVelocityComponent(increase),oldY);

				} else {
					
			newSpeed = new Vector2(oldX,generateRandomVelocityComponent(increase));

				}

		return newSpeed;
	
	}

	float generateRandomVelocityComponent(bool isIncreasing){

		float comp = VELOCITY_MODULE*Random.value;
		if (!isIncreasing)
		{
			comp*=-1;
		}
			return comp;
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








//
//		if (current_fish_x >= HORIZONTAL_UPPER_LIMIT && current_fish_y <= VERTICAL_UPPER_LIMIT) {
// 
//
//						print ("HU " + current_fish_x + ",VU" + current_fish_y);
//						rigidbody2D.velocity = generateRandomVelocity (false, false);
//
//				} else if (current_fish_x >= HORIZONTAL_UPPER_LIMIT && current_fish_y >= VERTICAL_BOTTOM_LIMIT) {
//
//						print ("HU " + current_fish_x + ",VB" + current_fish_y);
//						rigidbody2D.velocity = generateRandomVelocity (false, true);
//				}
//
//		else if (current_fish_x <= HORIZONTAL_BOTTOM_LIMIT && current_fish_y <= VERTICAL_UPPER_LIMIT) {
// 
//
//				print ("HB "+current_fish_x+",VU"+current_fish_y);
//				rigidbody2D.velocity = generateRandomVelocity (true,false);
//
//		} else if(current_fish_x <= HORIZONTAL_BOTTOM_LIMIT && current_fish_y >= VERTICAL_BOTTOM_LIMIT) {
//
//				print ("HB "+current_fish_x+",VB"+current_fish_y);
//				rigidbody2D.velocity = generateRandomVelocity (true,true);
//			}
// 
//		}
