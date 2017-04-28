using UnityEngine;
using System.Collections;

public class bulletControl : MonoBehaviour {

	private float bulletSpeed;
	private Transform playerPos;
	public Transform shootPos;
	private float closestDist;
	public GameObject particleHit;

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
		Destroy (gameObject,0.5f);

		if (shootPos != null) {
			transform.position = Vector3.MoveTowards (transform.position, shootPos.position, Time.deltaTime * bulletSpeed);
			transform.right = shootPos.position - transform.position;
		} else {
			Destroy (gameObject);

		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Instantiate (particleHit, transform.position, transform.rotation);
			particleHit.GetComponent<ParticleSystem>().loop = false;
			Destroy (gameObject);
		}
	}
}