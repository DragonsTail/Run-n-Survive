using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {


	private float walkSpeed;

	// Use this for initialization
	void Start () {
		//playerSprite.flipX = false;

	
		walkSpeed = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//--------------------KEYBOARD CONTRLS

			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);

			}
			if (Input.GetKey ("w")) {
				transform.Translate (Vector2.up * walkSpeed * Time.deltaTime);
			}
			if (Input.GetKey ("s")) {
				transform.Translate (Vector2.down * walkSpeed * Time.deltaTime);
			}
	}

}
