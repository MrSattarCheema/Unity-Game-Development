using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int speed = 8;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float canFire = -1f;
    [SerializeField]
    private float fireRate = .1f;
    [SerializeField]
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movemoent();
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > canFire)) {
            FireLaser();
        }
    }
    void Movemoent()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        // transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        // anothr way to do
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        //if (transform.position.y >= 5.7)
        //{
        //    transform.position = (new Vector3(transform.position.x, 5.7f, 0));
        //}
        //else if (transform.position.y < -3)
        //{
        //    transform.position = (new Vector3(transform.position.x, -3, 0));
        //}
        //  Instead of using if else statement we can aslo use clamp
        transform.position = new Vector3(transform.position.x, Math.Clamp(transform.position.y, -3f, 5.5f), 0);
        if (transform.position.x >= 9)
        {
            transform.position = (new Vector3(-8, transform.position.y, 0));
        }
        else if (transform.position.x < -8)
        {
            transform.position = (new Vector3(9, transform.position.y, 0));
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void FireLaser()
    {
        canFire = Time.time + fireRate;
        //Debug.Log($"fire rate {canFire} and time {Time.time}");
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + .8f, transform.position.z), Quaternion.identity);
    }
    public void Demage()
    {
        lives--;
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
