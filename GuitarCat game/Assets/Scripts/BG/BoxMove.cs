﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour {

	public float boxSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(PlayerAnimation.instance.playerDied == false){
			StartCoroutine(ObstacleMove());
		} else {
			boxSpeed = 0f;
		}
		
	}

	IEnumerator ObstacleMove(){
		yield return new WaitForSeconds(0.9f);
		transform.Translate(Vector3.left * boxSpeed);
	}
}
