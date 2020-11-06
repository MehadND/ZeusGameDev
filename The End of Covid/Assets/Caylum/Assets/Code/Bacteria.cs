using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bacteria : MonoBehaviour
{
    public Player myPlayer;
    public GameObject Bact;
    public GameObject Player;
    public Rigidbody2D bacteria;
    public float speed;
    public Transform player;
    private Vector2 movement;
    //public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBacteria", 3, 4);
        //MoveBacteria();
        bacteria = this.GetComponent<Rigidbody2D>();
    }

    /*void MoveBacteria()
    {
        Player = GameObject.Find("Player");
        if (Player != null)
        {
            if (transform.position.y > Player.transform.position.y)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if (transform.position.x < Player.transform.position.x)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

    }*/

    void SpawnBacteria()
    {
        Rigidbody2D bacteriaInstance;
        //Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(10.0f, 10.0f));
        bacteriaInstance = Instantiate(bacteria, new Vector3(UnityEngine.Random.Range(2f, 8f), UnityEngine.Random.Range(-4f, 4f), 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        bacteriaInstance.name = "Bacteria(Clone)";
        bacteriaInstance.velocity = new Vector2(speed, 0);
        if(myPlayer.getLives() == 0)
        {
            Destroy(bacteriaInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bacteria.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        bacteria.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            myPlayer.increaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "EnemyBox")
        {
            Destroy(gameObject);
        }
    }
}