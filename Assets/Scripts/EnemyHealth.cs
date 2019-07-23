using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 500;
    [SerializeField] float FireFrequency = 2f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 2f;

    float time = 0f;

    private void Start()
    {
        time = FireFrequency;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            shoot();
            time = FireFrequency;
        }
    }

    private void shoot()
    {
        var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= collision.GetComponent<Damage>().getDamage();
        Destroy(collision.gameObject);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
