using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField]
    private Transform[] enemy;
    [SerializeField]
    private Transform enemyParent;
    public float timer = 3f;
    [SerializeField]
    private float minY, maxY, posX;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAnimation.instance.playerDied == false)
        {
            if (timer <= 0)
            {
                SpawnEnemy(true);
            }
            timer -= Time.deltaTime;
        }
    }

    void SpawnEnemy(bool started)
    {
        if (started)
        {
            Vector3 enemyPosition = new Vector3(posX, Random.Range(minY, maxY), 0f);
            int index = Random.Range(0, enemy.Length);
            Transform createEnemy = (Transform)Instantiate(
                enemy[index], enemyPosition, Quaternion.Euler(180f, 0f, 180f)
                );
            createEnemy.parent = enemyParent;
            timer = 4f;
        }
    }
}
