using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{

    private new Renderer renderer;
    private Vector2 offset;

    public float groundSpeed = 1f;
    [HideInInspector] public bool groundScroll;
    public float scrollSpeed = -5f;
    Vector2 startPos;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (groundScroll && PlayerAnimation.instance.playerDied == false)
        {
            offset = new Vector2(Time.time * groundSpeed, 0);
            renderer.material.mainTextureOffset = offset;

			float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
			transform.position = startPos + Vector2.right * newPos;
        }
    }
}
