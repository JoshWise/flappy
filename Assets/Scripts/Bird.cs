using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  public GameManager gameManager;
    public Score score;

    public float speed;
    public float down;
    Rigidbody2D rb;
    int angle;
    int maxAngle = 20;
    int minAngle = -90;
    bool touchedGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        BirdRotation();


    }
    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
            else if (rb.velocity.y < down)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
            if (touchedGround == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gate"))
        {
            print("We have scored");
            score.Scored();
        }
        else if (collision.CompareTag("pipe"))
        {
          //gameOver
              
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (GameManager.gameOver == false)
            {
              gameManager.GameOver();
                //game over
            }
            else
            {
                touchedGround = true;
            }
        }
    }

}


