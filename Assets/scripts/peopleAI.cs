using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class peopleAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerMove.peopleCount += 1;
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Enemy") 
		{
			playerMove.peopleDeadCount += 1;
			Destroy (gameObject);
		}
	}

}
