using UnityEngine;
using System.Collections;

public class ammoScript : MonoBehaviour {

	private Animator anim;

	void Start()
	{

		anim = GetComponent<Animator>();
		anim.SetInteger ("restockAnim", 0);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			anim.SetInteger ("restockAnim", 1);
			StartCoroutine (reStockAmmo ());
			print ("Ammo restrocked");
			playerMove.ammoCount += 20;

		}
	}
	IEnumerator reStockAmmo()
	{
		yield return new WaitForSeconds (5);
		{
			anim.SetInteger ("restockAnim", 0);
		}
	}
}