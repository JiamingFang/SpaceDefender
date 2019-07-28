using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 500;
    [SerializeField] float FireFrequency = 2f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 2f;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.75f;
    [SerializeField] AudioClip fireClip;
    [SerializeField] [Range(0, 1)] float fireVolume = 0.75f;

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
        AudioSource.PlayClipAtPoint(fireClip, Camera.main.transform.position, fireVolume);
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

    private void OnDestroy()
    {
        GameObject explosion = Instantiate(deathExplosion, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathVolume);
    }

}
