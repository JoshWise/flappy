using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float newY;
    float groundWidth;
   
    float pipeWidth;
    float cloudWidth;

    BoxCollider2D box;
    BoxCollider2D cloudbox;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("ground"))
        { 
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("column"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("pipe").GetComponent<BoxCollider2D>().size.x;
        }
        else if (gameObject.CompareTag("cloud"))
        {
            cloudbox= GetComponent<BoxCollider2D>();
            cloudWidth= cloudbox.size.x;

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }

        if (gameObject.CompareTag("ground"))
        {
            if (transform.position.x <= -groundWidth/2 )
            {
                transform.position = new Vector2(
                    transform.position.x + groundWidth,
                    transform.position.y);
            }
        }
        else if (gameObject.CompareTag("cloud"))
        {
            if (transform.position.x <= -cloudWidth/2 )
            {
                transform.position = new Vector2(
                    transform.position.x + cloudWidth,
                    transform.position.y);
            }
        }
        else if (gameObject.CompareTag("column"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - pipeWidth)
            {
                Destroy(gameObject);
            
            }
        }

    }
}
 