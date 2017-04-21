using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {


	public GameObject enemyA;
	public int enemyACount;
	public Transform enemyATransform;
	//private float closeDistance = 10;

	private int gameClock;

	public GameObject startPanelUI;

	public Transform playerTarget;

	public GameObject exitDoorPrefab;
	public int exitDoorCount;

	public GameObject key;
	public int keyCount;

	public int mapHeight;
	public int mapWidth;

	public float envSize;

	public GameObject tilePrefab;
	public Transform [] doorLocator;

	private SpriteRenderer playerSprite;


	// Use this for initialization
	void Start () 
		{

	}

	void Update()
	{
	}

	IEnumerator enemyAspawn()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < enemyACount; i++) 

		{
			Vector3 position = new Vector3(Random.Range(-15,15),Random.Range(-10,10),0);
			Instantiate (enemyA, position, Quaternion.identity);
			yield return new WaitForSeconds (0.4f);
		}
	}
	IEnumerator exitDoor()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < exitDoorCount; i++) 
		{
			Vector3 position = new Vector3 (Random.Range (-15, 15), Random.Range (-10, 10), 0);
			Instantiate (exitDoorPrefab, position, Quaternion.identity);
		}
	}
	IEnumerator keySpawn()
	{
		yield return new WaitForSeconds (0);
		for (int i = 0; i < keyCount; i++) 
		{
			Vector3 position = new Vector3 (Random.Range (-15, 15), Random.Range (-10, 10), 0);
			//Vector3 position = new Vector3[doorLocator];
			Instantiate (key, position, Quaternion.identity);
		}
	}
	public void gameStart()
	{
		Time.timeScale = 1;
		startPanelUI.SetActive(false);



		//		mapWidth = Random.Range (1, 12);
		//		mapHeight = Random.Range (1, 8);

		mapWidth = Random.Range (3, 3);
		mapHeight = Random.Range (3, 3);

		enemyACount = Random.Range (15, 100);
		Time.timeScale = 1;

		exitDoorCount = 1;
		StartCoroutine (enemyAspawn ());
		StartCoroutine (keySpawn ());
		StartCoroutine (exitDoor ());

		for(int y = -1; y < mapHeight; y++)
		{
			for( int x = -1; x < mapWidth; x++)
			{
				Instantiate (tilePrefab, new Vector3 (x * envSize , y * envSize, 0), Quaternion.identity);
			}
		}
	}
	public void restartLevel()
	{
		SceneManager.LoadScene ("halTalks_scene_01");
	}


}
