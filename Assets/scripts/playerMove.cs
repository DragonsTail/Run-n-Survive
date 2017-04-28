using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class playerMove : MonoBehaviour {

//------UI-----
	public Text ammo;
	public static int ammoCount;
	public Text people;
	public static int peopleCount;
	public Text peopleDead;
	public static int peopleDeadCount;
	public Text endlevelScore;
	public Text enemyKills;
	public static int enemyKillsCounter;
	public Text UIKillsCounter;
	public GameObject infoGamePanel;
	public GameObject loosePanel;
	public GameObject winPanel;
	public Text finishGameText;

//----Gameobjects----
	public Transform target;
	public float followSpeed = 6f;
	public static bool shootButton;
	public GameObject playerDieFX;
	public static bool killAll;
	public static bool playerDead;
	public GameObject exitDoorPrefab;
	public int exitDoorCount;
	private float spawnWidth = 10f;
	private float spawnHeight =5f;


//-----Bullets------
	public GameObject bulletPrefab;
	public bool gunReloadTime;
	public Transform other;

	void Start () {
		playerDead = false;
		killAll = false;
		peopleCount = 0;
		peopleDeadCount = 0;
		infoGamePanel.gameObject.SetActive (false);
		loosePanel.gameObject.SetActive (false);
		winPanel.gameObject.SetActive (false);
		StartCoroutine (infoBanner ());
		gunReloadTime = true;
		//ammoCount = 20;
		//followSpeed = Random.Range (20f, 40f);
		enemyKillsCounter = 0;
	}
	IEnumerator infoBanner()
	{
		yield return new WaitForSeconds (1f);
		{
			infoGamePanel.gameObject.SetActive (false);
		}
	}

	IEnumerator exitDoor()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < exitDoorCount; i++) 
		{
			Vector3 position = new Vector3 (Random.Range (-spawnHeight, spawnHeight), Random.Range (-spawnWidth, spawnWidth), 0);
			Instantiate (exitDoorPrefab, position, Quaternion.identity);
		}
	}
	void Update()
	{
		//UI unit counters
		people.text = peopleCount.ToString ();
		peopleDead.text = peopleDeadCount.ToString ();
		endlevelScore.text = peopleCount.ToString ();
		enemyKills.text = enemyKillsCounter.ToString ();
		UIKillsCounter.text = enemyKillsCounter.ToString ();



		if (Input.GetKey (KeyCode.D)) {
			transform.localScale = new Vector3 (-4, 4, 4);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.localScale = new Vector3 (4, 4, 4);
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
				return;
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
		//--This is the code for the player to follow the camera if the camera is used to move around the world.--
		//transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "key")
		{
			Debug.Log ("Key Collision");
			StartCoroutine (exitDoor ());

		}
		if(keyTrigger.hasKey)
		{
			if (other.gameObject.tag == "door") 
			{
				endLevel ();
				//winPanel.gameObject.SetActive (true);
				loosePanel.gameObject.SetActive (true);

			}
		}
		if(other.gameObject.tag == "Enemy")
		{
			Instantiate (playerDieFX, transform.position, transform.rotation);
			loosePanel.gameObject.SetActive (true);
			endLevel ();
		}
	}
	void updateAmmo()
	{
		ammo.text = ammoCount.ToString ();
	}
	void endLevel()
	{
		Instantiate (playerDieFX, transform.position, transform.rotation);
		killAll = true;
		Destroy (gameObject);
		playerDead = true;
		Time.timeScale = 0;
		//peopleCount = 0;
		//peopleDeadCount = 0;
	}
}