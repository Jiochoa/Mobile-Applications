using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

	public GameObject[] box;

	public float timer;
	public float boxPos;

	[HideInInspector]
	public bool canSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canSpawn && PlayerAnimation.instance.playerDied == false){
			if(timer <= 0){
				Spawner();
			}
			timer -= Time.deltaTime;
		}
	}

	void Spawner(){
		int index = Random.Range(0, box.Length);
		Instantiate(box[index], new Vector3(boxPos, 0, 0), Quaternion.Euler(0, 0, 0));
		timer = 2f;
	}
}
