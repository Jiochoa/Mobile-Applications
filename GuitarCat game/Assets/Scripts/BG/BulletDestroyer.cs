using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "PlayerBullet"){
			Destroy(col.gameObject);
		}
	}
}
