﻿using UnityEngine;
using System.Collections;

public class lookingScript : MonoBehaviour {


	public Transform target;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.right = target.position - transform.position;
	}
}
