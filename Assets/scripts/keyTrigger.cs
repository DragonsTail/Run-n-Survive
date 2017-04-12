using UnityEngine;
using System.Collections;

public class keyTrigger : MonoBehaviour {


	public static bool hasKey;

	// Use this for initialization
	void Start () {
		hasKey = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			hasKey = true;
			Destroy (gameObject);
		}
	}
}
