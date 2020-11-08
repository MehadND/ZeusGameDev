using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss2 : MonoBehaviour
{
    public Player myPlayer;
    public GameObject bossPlayer2;
    public GameObject Player;
    public Rigidbody2D boss2;
    public float speed;
    public Transform player;
    private Vector2 movement;
    public GUIStyle myStyle;

    //public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        //MoveBacteria();
        boss2 = this.GetComponent<Rigidbody2D>();

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
        boss2.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        boss2.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            myPlayer.increaseScore();
            Destroy(collision.gameObject);
            Boss.bossLives -= 5;
        }

    }
    void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, 100, 30), "Time: " + (int)Time.timeSinceLevelLoad, myStyle);
        //GUI.Box(new Rect(10, 170, 100, 30), "boss Health: " + bossLives, myStyle);
    }
}