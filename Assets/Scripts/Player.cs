using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] int xSpeed = 10;
    [SerializeField] int ySpeed = 10;
    [SerializeField] float padding = 1f;
    [Header("Laser")]
    [SerializeField] GameObject laser;
    [SerializeField] int laserSpeed = 20;
    [Header("Health")]
    [SerializeField] int health = 500;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine fire1;

	// Use this for initialization
	void Start () {
        Camera main = Camera.main;
        xMin = main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        
    }
	
	// Update is called once per frame
	void Update () {
        movement();
        fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= collision.GetComponent<Damage>().getDamage();
        Destroy(collision.gameObject);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire1 = StartCoroutine(fireContinuous());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fire1);
        }
    }

    IEnumerator fireContinuous()
    {
        while (true)
        {
            GameObject laserObject = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void movement()
    {
        var newX = Mathf.Clamp( transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed,xMin,xMax);
        var newY = Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * ySpeed,yMin,yMax);
        transform.position = new Vector2(newX, newY);
        
    }
}
