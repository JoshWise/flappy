using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector2 bottomLeft;
    //game states
    public static bool gameOver;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    public void GameOver () {
        gameOver = true;
    }
    void Update()
    {
       
    }
}
