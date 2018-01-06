using UnityEngine;
using System.Collections;

public class moveRacket : MonoBehaviour {

	public float speed = 30;
	public string axis = "Vertical";

	void Start(){
	}

	void FixedUpdate () {
	
		float v = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, v) * speed;
	}

	public void resetRackets(){
	
		if (this.name == "rightRacket"){
			transform.position = new Vector2(60, 0);
		}
		
		if (this.name == "leftRacket") {
			transform.position = new Vector2 (-60, 0);
		}
	}
}
