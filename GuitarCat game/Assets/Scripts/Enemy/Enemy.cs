using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public AudioClip hitSound, bulletSound;

	private Animator myAnimator;
	[HideInInspector]
	public bool canFlap;

	public GameObject playerEffect;
	public GameObject enemyBullet;
	public float timer = 3f;
	public float enemyBulletForce = 30f;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
		canFlap = true;
	}
	
	void Update () {
		if(canFlap){
			myAnimator.SetBool("flying", true);
		}
		if(timer <= 0){
			EnemyShoot();
			timer = 2f;
		}
		timer -= Time.deltaTime;
	}

	public void EnemyShoot(){
		if (PlayerAnimation.instance.playerDied == false) {
			Vector3 offset = new Vector3 (transform.position.x-1.3f, transform.position.y, 0f);
			GameObject newBullet = Instantiate (enemyBullet, offset, Quaternion.Euler (0f, 0f, 180f)) as GameObject;
			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-enemyBulletForce, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" || other.tag == "Player Cat"){
			GamePlayScript.instance.PlayerTakeDamage();
			Instantiate(playerEffect, PlayerAnimation.instance.transform.position, Quaternion.identity);
			Destroy(gameObject);
			Destroy(other.gameObject);
			PlayerAnimation.instance.playerDied = true;
			AudioSource.PlayClipAtPoint(hitSound, PlayerAnimation.instance.transform.position, 2f);
		}

		if(other.tag == "PlayerBullet"){
			GamePlayScript.instance.PlayerDestroyEnemy();
			GameObject effect = Instantiate(playerEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy(gameObject);
			Destroy(other.gameObject);
			Destroy(effect, 0.5f);
			AudioSource.PlayClipAtPoint(bulletSound, transform.position, 2f);
		}
	}
}
