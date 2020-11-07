using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public static int lives = 3;
    public static int score = 0;

    public Animator animator;
    public GUIStyle myStyle;
    public Rigidbody2D rb;

    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            lives = 3;
            score = 0;
            SceneManager.LoadScene("Level 1");
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        MoveCharacter();
    }


    void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("right", false);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("up", true);
            down = false;
            left = false;
            right = false;
            up = true;
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("left", true);
            down = false;
            left = true;
            right = false;
            up = false;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("right", false);
            animator.SetBool("down", true);
            down = true;
            left = false;
            right = false;
            up = false;
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("right", true);
            down = false;
            left = false;
            right = true;
            up = false;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
           
        //Have an idle animation
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, 100, 30), "Time: " + (int)Time.timeSinceLevelLoad, myStyle);
        GUI.Box(new Rect(10, 60, 100, 30), "Lives: " + lives, myStyle);
        GUI.Box(new Rect(10, 110, 100, 30), "Score: " + score, myStyle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.name == "Bacteria(Clone)")
        {
            lives = lives - 1;
            rb.transform.position *= (float)-3.0;
            //player.transform.position = new Vector2((float)(player.transform.position.x*0.2), (float)(player.transform.position.y * 0.2));
        }
    }

    public void increaseScore()
    {
        score += 15;
        if (score >= 200)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
        }
    }

    public int getLives()
    {
        return lives;
    }


}
