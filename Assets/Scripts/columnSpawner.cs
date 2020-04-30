using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnSpawner : MonoBehaviour
{
    public GameObject column;
    float randY;
    public float maxY;
    public float minY;
    public float maxTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {

        InstantiateColumn();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                InstantiateColumn();
                timer = 0;

            }
        }


    }
    void InstantiateColumn()
    {
        randY = Random.Range(minY, maxY);

        GameObject newColumn = Instantiate(column);
        newColumn.transform.position = new Vector2(transform.position.x, randY);
    }
}
