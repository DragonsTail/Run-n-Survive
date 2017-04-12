using UnityEngine;
using System.Collections;

public class enemyAI_ : MonoBehaviour {


	private float walkSpeed;
	public Transform target;


	// Use this for initialization
	void Start () {

		walkSpeed = 3f;
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * walkSpeed);
	
	}
}
