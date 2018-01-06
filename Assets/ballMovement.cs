using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {

	public float speed = 60;
	public GameObject GO;
	private gameManager GM;

	// Use this for initialization
	void Start () {

		GM = GO.GetComponent<gameManager> ();
		Invoke ("initialDirection", 2);
	}


	public void initialDirection () {
		float rand = Random.Range (0, 2);
		if (rand == 1) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * speed;
		} 
		else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (1, 0) * speed;
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.name == "rightRacket") {
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

			GetComponent<Rigidbody2D>().velocity = new Vector2(-1, y).normalized * speed;

		}

		if (col.gameObject.name == "leftRacket") {
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

			GetComponent<Rigidbody2D>().velocity = new Vector2(1, y).normalized * speed;


		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {

		return (ballPos.y - racketPos.y) / racketHeight;
	}

	public void resetBall() {
		transform.position = Vector2.zero;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}



	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.name == "rightWall" || coll.gameObject.name == "leftWall") {
			string wallName = coll.gameObject.name;
			resetBall ();
			GM.AddOneToScore (wallName);
			GM.leftRacket.transform.position = new Vector2 (-60, 0);
			GM.rightRacket.transform.position = new Vector2 (60, 0);
			Invoke ("initialDirection", 2);

		}
	}

}