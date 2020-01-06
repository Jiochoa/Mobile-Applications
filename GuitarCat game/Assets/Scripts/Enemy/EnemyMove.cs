using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public float enemySpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(PlayerAnimation.instance.playerDied == false){
			StartCoroutine(MoveEnemy());
		} else {
			enemySpeed = 0f;
		}
	}

	IEnumerator MoveEnemy(){
		yield return new WaitForSeconds(0.7f);
		transform.Translate(Vector3.right * enemySpeed);
	}
}
