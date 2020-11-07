using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    public Player myPlayer;
    public GameObject bossPlayer;
    public GameObject Player;
    public Rigidbody2D boss;
    public float speed;
    public Transform player;
    private Vector2 movement;
    public int bossLives = 200;
    public GUIStyle myStyle;

    //public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        //MoveBacteria();
        boss = this.GetComponent<Rigidbody2D>();
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


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        boss.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        boss.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            myPlayer.increaseScore();
            Destroy(collision.gameObject);
            bossLives--;
        }

        if (collision.gameObject.name == "EnemyBox")
        {
            Destroy(gameObject);
        }
    }
    void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, 100, 30), "Time: " + (int)Time.timeSinceLevelLoad, myStyle);
        GUI.Box(new Rect(10, 170, 100, 30), "Boss Health: " + bossLives, myStyle);
    }
}