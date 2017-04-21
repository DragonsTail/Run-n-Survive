using UnityEngine;
using System.Collections;

public class monsterA : MonoBehaviour {


	//public Transform target;
	private float walkSpeed; 
	private Transform target;
	private GameObject go;
	public float dist;
	public GameObject explosion;


	void Start ()
	{
		walkSpeed = Random.Range(2f,4f);

		GameObject go =  GameObject.FindGameObjectWithTag("Player");
		if (go != null) {
			target = go.transform;
		}
		else {
			target = null;
		}
	}
	void FixedUpdate () 
	{
		StartCoroutine (enemyAttack ());
	}
	IEnumerator enemyAttack()
	{
		yield return new WaitForSeconds (0.8f);
		{
			this.GetComponent<BoxCollider2D>().enabled = true;
			dist = Vector3.Distance (transform.position, target.position);
			if(dist < 10f)
			{
				transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * walkSpeed);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "bullet")
		{	
			this.GetComponent<Collider2D>().isTrigger = true;

			StartCoroutine (enemyDie());
		}
	}
	IEnumerator enemyDie()
	{
		yield return new WaitForSeconds (0.0f);
		{
			playerMove.enemyKillsCounter += 1;
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}