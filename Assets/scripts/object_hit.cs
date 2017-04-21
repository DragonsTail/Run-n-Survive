using UnityEngine;
using System.Collections;

public class object_hit : MonoBehaviour {

	public GameObject collisionFX;
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			print ("Hit made");
			Instantiate(collisionFX, target.transform.position, target.transform.rotation);
		}
	}
}
