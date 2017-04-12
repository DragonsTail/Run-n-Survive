using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class playerMove : MonoBehaviour {


	public Text ammo;
	public Transform target;
	public float followSpeed = 6;
	public Text finishGameText;
	public GameObject infoGamePanel;
	public GameObject loosePanel;
	public GameObject winPanel;
	public static int ammoCount;
	public static bool shootButton;
	public GameObject playerDieFX;

// Bullets
	public GameObject bulletPrefab;
	public bool gunReloadTime;

	public Transform other;

	void Start () {

		infoGamePanel.gameObject.SetActive (false);
		loosePanel.gameObject.SetActive (false);
		winPanel.gameObject.SetActive (false);
		StartCoroutine (infoBanner ());
		gunReloadTime = true;
		ammoCount = 20;
	}
	IEnumerator infoBanner()
	{
		yield return new WaitForSeconds (1f);
		{
			infoGamePanel.gameObject.SetActive (false);
		}
	}
	void Update()
	{

		if (Input.GetKey (KeyCode.D)) {
			transform.localScale = new Vector3 (-2, 2, 2);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.localScale = new Vector3 (2, 2, 2);
					}
		if (Input.GetKeyDown ("m"))
		{
			if (ammoCount > 0) {
				Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

					if (gunReloadTime) {
						StartCoroutine (fireBullet ());
						Instantiate (bulletPrefab, transform.position, transform.rotation);
					}
				ammoCount -= 1;
				updateAmmo ();
			} else {
				print ("No ammo");
			}
		} 
		if (ammoCount <= 0) {
			ammoCount = 0;
			updateAmmo ();
		}

			
	}

	IEnumerator fireBullet()
	{
		shootButton = false;
		{
			gunReloadTime = false;
		}
		yield return new WaitForSeconds (0.1f);
		gunReloadTime = true;
	}

	void FixedUpdate () 
	{

		transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "key")
		{
			Debug.Log ("Key Collision");
		}
		if(keyTrigger.hasKey)
		{
			if (other.gameObject.tag == "door") 
			{
				Destroy (gameObject);
				winPanel.gameObject.SetActive (true);
				Time.timeScale = 0;
				finishGameText.text = "You made it!";
				Debug.Log ("Exit Collision");
			}
		}

		if(other.gameObject.tag == "Enemy")
		{
			Instantiate (playerDieFX, transform.position, transform.rotation);

			Destroy (gameObject);
			loosePanel.gameObject.SetActive (true);
			Time.timeScale = 0;
			finishGameText.text = "Game Over";
		}
	}

	void updateAmmo()
	{
		ammo.text = ammoCount.ToString ();
	}
}