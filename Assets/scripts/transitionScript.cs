using UnityEngine;
using System.Collections;

public class transitionScript : MonoBehaviour {


	public Transform startUI;
	public Transform endUI;
	private float speedIn;
	private float speedOut;
	private bool buttonPress;

	// Use this for initialization
	void Start () {
		speedIn = 0.1f;
		speedOut = 0.1f;
		buttonPress = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.Lerp (transform.position, endUI.position, speedIn);
			if (buttonPress == true)
			{
				speedIn = 0;
				transform.position = Vector3.Lerp (transform.position, startUI.position, speedOut);
			}
	}
	public void hideUI()
	{
		//if (transform.position == endUI.position) 
		{
			buttonPress = true;
		}
	}
}
