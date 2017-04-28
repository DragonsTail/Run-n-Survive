using UnityEngine;
using System.Collections;

public class monsterA : MonoBehaviour {


	//public Transform target;
	private float walkSpeed; 
	private Transform target;
	private GameObject go;
	public float dist;
	public GameObject explosion;

	public float MinWalkSpeed = 2f;
	public float MaxWalkSpeed = 4f;

	public float maxHealth = 100;
	public float currentHealth = 0;
	public float damage;
	public GameObject healthBar;

	void Start ()
	{
		walkSpeed = Random.Range(MinWalkSpeed,MaxWalkSpeed);

		GameObject go =  GameObject.FindGameObjectWithTag("Player");
		if (go != null) {
			target = go.transform;
		}
		else {
			target = null;
		}

		currentHealth = maxHealth;
	}
	void FixedUpdate () 
	{
		StartCoroutine (enemyAttack ());
		if (playerMove.killAll == true) {
			Destroy (gameObject);
		}
	}
	IEnumerator enemyAttack()
	{
		yield return new WaitForSeconds (0.8f);
		{
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
			//health--;
			currentHealth -= damage;
			float calcHealth = currentHealth / maxHealth;
			setHealthBar (calcHealth);

			if (currentHealth <= 0) 
			{
				playerMove.enemyKillsCounter += 1;
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
	public void setHealthBar( float myHealth)
	{
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}