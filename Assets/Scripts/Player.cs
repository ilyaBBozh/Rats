using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private bool isLeft;
    public Transform dd;
    private bool isDown;
    public LayerMask dLayer;
    private Animator anim;
    public int health = 5;
    public Text healthText;
    public GameObject gameOverText;
    public AudioSource gameOverSource;
    public AudioSource pickupGoodObjectSource;
    public AudioSource hurtSource;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        isLeft = false;

        Time.timeScale = 1;
    }

    private void Update()
    {
        healthText.text = "Health: " + health;

        if(health <= 0)
        {
            GameOver();
        }

		isDown = Physics2D.OverlapCircle(dd.position, 0.1f, dLayer);

		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            sr.flipX = isLeft;
            isLeft = false;

            anim.SetInteger("isRun", 1);

            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            sr.flipX = isLeft;
            isLeft = true;

            anim.SetInteger("isRun", 1);

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) 
        {
            anim.SetInteger("isRun", 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && isDown == true)
        {
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void GameOver()
    {
        gameOverSource.Play();
        gameOverText.active = true;
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}
