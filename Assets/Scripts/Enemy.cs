using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject explosionFactory;
    float angle;

    Vector3 dir;

    private void Start()
    {
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");

        if (randValue < 3 && target != null)
        {
            angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }

    }

    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = this.transform.position;

        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
