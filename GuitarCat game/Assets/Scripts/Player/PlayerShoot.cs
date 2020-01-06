using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public AudioClip bulletSound;

	private Animator myAnimator;

	public GameObject playerBullet;
	public float bulletForce = 30f;
	public float timeBetweenShots = 0.3333f;
	private float shotTimeStamp;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerAnimation.instance.gameStarted && PlayerAnimation.instance.playerDied == false){
			if(Time.time >= shotTimeStamp && ValidShootKeyPressed()){
				myAnimator.SetBool("shoot", true);
				StartCoroutine(PlayerShootBullet(0.1f));
				shotTimeStamp = Time.time + timeBetweenShots;
				// new WaitForSeconds(2);
			}

			if(Input.GetKeyUp(KeyCode.A) || Input.touchCount != 2){
				myAnimator.SetBool("shoot", false);
			}
		}
	}

	bool ValidShootKeyPressed()
	{
		return (Input.GetKeyDown(KeyCode.A) || Input.touchCount == 2 );
	}

	IEnumerator PlayerShootBullet(float startTime){
		yield return new WaitForSeconds(startTime);
		Vector3 offset = new Vector3 (transform.position.x-0.1f, transform.position.y-0.1f, 0f);
		GameObject newBullet = Instantiate (playerBullet, offset, Quaternion.Euler (0f, 0f, 0f)) as GameObject;
		newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (bulletForce, 0f);
		AudioSource.PlayClipAtPoint(bulletSound, transform.position, 2f);
	}
}
