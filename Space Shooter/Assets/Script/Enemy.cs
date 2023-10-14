using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame y=6.37 and -4, x = -9.7 and 9.7
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -4f)
        {
            float randomX = Random.Range(-9, 9);
            transform.position = new Vector3(randomX, 6.37f, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Demage();
            }
            Destroy(this.gameObject);
        }
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
