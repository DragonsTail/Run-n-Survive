using UnityEngine;
using System.Collections;

public class ammoScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerMove.ammoCount += 20;
			print ("Ammo restrocked");
			Destroy (gameObject);
			playerMove.enemyKillsCounter += 1;
		}
	}
}