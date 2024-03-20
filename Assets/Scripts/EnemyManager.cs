using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime = 0f;
    float minTime = 1.0f;
    float maxTime = 5.0f;

    public float createTime = 1.0f;
    public GameObject enemyFactory;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0f;
        }
    }
}
