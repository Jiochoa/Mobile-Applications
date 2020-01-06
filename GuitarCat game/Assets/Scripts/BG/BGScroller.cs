using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    // private MeshRenderer meshRenderer;
    // private Material _material;

    // public float speed = -0.001f;
    // public float currentscroll;

    [HideInInspector]
    public bool canScroll;
	public float scrollSpeed = -5f;
	Vector2 startPos;


    void Start()
    {
        // meshRenderer = GetComponent<MeshRenderer>();

        // _material = GetComponent<MeshRenderer>().material;

		startPos = transform.position;
    }

    void Update()
    {
        if (canScroll && PlayerAnimation.instance.playerDied == false)
        {
            // meshRenderer.material.mainTextureOffset -= new Vector2(
            //     speed * Time.deltaTime, 0
            // );

            // currentscroll -= speed * Time.deltaTime;
            // _material.mainTextureOffset = new Vector2(currentscroll, 0);

			float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
			transform.position = startPos + Vector2.right * newPos;


        }
    }
}
