using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }

        if (col.tag == "Middle")
        {
            Destroy(col.gameObject);
        }

		if(col.tag == "Player" || col.tag == "Player Cat")
		{
			PlayerAnimation.instance.DiedThroughCollison();
		}

		// PlayerAnimation.D
    }
}
