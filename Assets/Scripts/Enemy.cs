using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;

    Vector3 dir;

    private void Start()
    {
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");

        if (randValue < 3)
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else {
            dir = Vector3.down;
        }

    }

    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
