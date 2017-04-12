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
		walkSpeed = (Random.Range(1.0f, 2.0f));

		this.GetComponent<BoxCollider2D>().enabled = false;

		GameObject go =  GameObject.FindGameObjectWithTag("Player");
		if (go != null) {
			target = go.transform;
		}
		else {
			target = null;
		}

		StartCoroutine (enemyAttack ());
	}
	void FixedUpdate () 
	{
		dist = Vector3.Distance (transform.position, target.position);
		if(dist < 10f)
		{
		transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * walkSpeed);
		}
	
	}
	IEnumerator enemyAttack()
	{
		yield return new WaitForSeconds (0.8f);
		{
			this.GetComponent<BoxCollider2D>().enabled = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "bullet")
		{
			Instantiate(explosion,transform.position,transform.rotation);
			Destroy (gameObject);
		}
	}
}