using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public static PlayerAnimation instance;

    public AudioClip jumpSound, hitSound;

    private Animator myAnim;
    private Rigidbody2D myRigidbody;
    [HideInInspector]
    public bool gameStarted;
    private BGScroller bgScroller;
    private GroundScroller groundScroller;
    private BoxSpawner boxSpawner;

    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private PolygonCollider2D polygonCollider;

    public LayerMask groundLayer;
    public float jump = 10f;
    public Transform groundCheckPos;
    public float radius = 0.5f;
    [HideInInspector]
    public bool isGrounded;
    public GameObject playerDiedEffect;
    [HideInInspector]
    public bool playerDied = false;



    void Awake()
    {
        myAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        bgScroller = GameObject.Find("Background").GetComponent<BGScroller>();
        groundScroller = GameObject.Find("Ground").GetComponent<GroundScroller>();
        boxSpawner = GameObject.Find("BoxSpawner").GetComponent<BoxSpawner>();

        Physics2D.IgnoreCollision(boxCollider, polygonCollider, true);
    }


    void Start()
    {
        MakeInstance();
        StartCoroutine(StartGame());
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void PlayerGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, radius, groundLayer);
    }

    void Update()
    {
        if (gameStarted && playerDied == false)
        {
            myAnim.SetFloat("walk", 1f);
            PlayerGrounded();

            PlayerJump();
        }
    }

    void PlayerJump()
    {

        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount == 1))
        {
            if (gameStarted && isGrounded)
            {
                myAnim.SetBool("jump", true);
                myRigidbody.AddForce(new Vector3(0, jump, 0));
                AudioSource.PlayClipAtPoint(jumpSound, transform.position, 2f);
            }
        }
        else
        {
            myAnim.SetBool("jump", false);
        }
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        bgScroller.canScroll = true;
        groundScroller.groundScroll = true;
        boxSpawner.canSpawn = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Box")
        {
            // DiedThroughCollison();
        }

        if (target.gameObject.tag == "EnemyBullet")
        {
            GamePlayScript.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(target.gameObject);
            playerDied = true;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 2f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Middle")
        {
            GamePlayScript.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            playerDied = true;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 2f);
        }
    }

    public void DiedThroughCollison()
    {
        GamePlayScript.instance.PlayerTakeDamage();
        Vector3 effectPosition = transform.position;
        Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
        Destroy(gameObject);
        playerDied = true;
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 2f);
    }
}
