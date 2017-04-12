using UnityEngine;
using System.Collections;

public class bulletControl : MonoBehaviour {

	private float bulletSpeed;
	private Transform playerPos;
	public Transform shootPos;
	private float closestDist;

	void Start ()
	{
		bulletSpeed = 20f;
		closestDist = 1000;
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform;

		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject closestEnemy in gos) 
		{
			float dist = Vector3.Distance (closestEnemy.gameObject.transform.position, playerPos.position);
			if (dist < closestDist) 
			{
				closestDist = dist; 
				//shootPos.transform.position = closestEnemy.transform.position;
				shootPos = closestEnemy.transform;
				transform.position = Vector3.MoveTowards (transform.position, shootPos.position, Time.deltaTime * bulletSpeed);
			} 
		}
	}
	void Update()
	{
		if (shootPos != null) {
			transform.position = Vector3.MoveTowards (transform.position, shootPos.position, Time.deltaTime * bulletSpeed);
			transform.right = shootPos.position - transform.position;
		} else {
			Destroy (gameObject);

		}
		//Destroy (gameObject, 0.4F);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy (gameObject);
		}
	}
}