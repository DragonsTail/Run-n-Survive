using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {


	public GameObject enemyA;
	public int enemyACount;
	public Transform enemyATransform;
	public GameObject enemyB;
	public int enemyBCount;
	public Transform enemyBTransform;

	public GameObject ammobullet;
	public int ammoBulletCount;
	public Transform ammoBulletTransform;


	private int gameClock;

	public GameObject startPanelUI;

	public Transform playerTarget;

//	public GameObject exitDoorPrefab;
//	public int exitDoorCount;

	public GameObject key;
	public int keyCount;

	public int mapHeight;
	public int mapWidth;

	public float envSize;

	public GameObject tilePrefab;
	public Transform [] doorLocator;

	private SpriteRenderer playerSprite;

	private float spawnWidth = 10f;
	private float spawnHeight =5f;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
		startPanelUI.SetActive(true);
	}

	IEnumerator enemyAspawn()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < enemyACount; i++) 

		{
			Vector3 position = new Vector3(Random.Range(-spawnHeight,spawnHeight),Random.Range(-spawnWidth,spawnWidth),0);
			Instantiate (enemyA, position, Quaternion.identity);
			yield return new WaitForSeconds (0.4f);
		}
	}
	IEnumerator enemyBspawn()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < enemyBCount; i++)

		{
			Vector3 position = new Vector3(Random.Range(-spawnHeight,spawnHeight),Random.Range(-spawnWidth,spawnWidth),0);
			Instantiate (enemyB, position, Quaternion.identity);
			yield return new WaitForSeconds (0.4f);
		}
	}
	IEnumerator ammoBulletSpawn()
	{
		yield return new WaitForSeconds (4);
		for (int i = 0; i < ammoBulletCount; i++) 

		{
			Vector3 position = new Vector3(Random.Range(-spawnHeight,spawnHeight),Random.Range(-spawnWidth,spawnWidth),0);
			Instantiate (ammobullet, position, Quaternion.identity);
			yield return new WaitForSeconds (2f);
		}
	}
//	IEnumerator exitDoor()
//	{
//		yield return new WaitForSeconds (0);
//		for (int i = 0; i < exitDoorCount; i++) 
//		{
//			Vector3 position = new Vector3 (Random.Range (-spawnHeight, spawnHeight), Random.Range (-spawnWidth, spawnWidth), 0);
//			Instantiate (exitDoorPrefab, position, Quaternion.identity);
//		}
//	}
	IEnumerator keySpawn()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < keyCount; i++) 
		{
			Vector3 position = new Vector3 (Random.Range (-spawnHeight, spawnHeight), Random.Range (-spawnWidth, spawnWidth), 0);
			//Vector3 position = new Vector3[doorLocator];
			Instantiate (key, position, Quaternion.identity);
		}
	}
	public void gameStart()
	{

		Time.timeScale = 1;
		//startPanelUI.SetActive(false);

		//		mapWidth = Random.Range (1, 12);
		//		mapHeight = Random.Range (1, 8);

		mapWidth = Random.Range (0, 0);
		mapHeight = Random.Range (0, 0);

		//enemyACount = Random.Range (15, 100);
		Time.timeScale = 1;

		//exitDoorCount = 1;
		StartCoroutine (enemyAspawn ());
		StartCoroutine (enemyBspawn ());
		StartCoroutine (keySpawn ());
		StartCoroutine (ammoBulletSpawn ());
		//StartCoroutine (exitDoor ());


		for(int y = -1; y < mapHeight; y++)
		{
			for( int x = -1; x < mapWidth; x++)
			{
				//Instantiate (tilePrefab, new Vector3 (x * envSize , y * envSize, 0), Quaternion.identity);
			}
		}
		
	}
	public void restartLevel()
	{
		StartCoroutine (newGame ());
		Time.timeScale = 1;

	}
	IEnumerator newGame()
	{
		yield return new WaitForSeconds (0.5f);
		{
			restart ();
		}
	}
	void restart()
	{
		SceneManager.LoadScene ("halTalks_scene_01");

	}
}
