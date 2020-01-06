using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour {

	public AudioClip scoreSound;

	void OnCollisionEnter2D(Collision2D target){
		if((target.gameObject.tag == "Player" || target.gameObject.tag == "Player Cat") && PlayerAnimation.instance.playerDied == false){
			GamePlayScript.instance.IncrementScore();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(scoreSound, transform.position, 2f);
		}
	}
}
