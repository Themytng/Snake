using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    //variables
    public BoxCollider2D grid;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function for randomized position
    private void RandomPos()
    {
        Bounds bounds = grid.bounds;  //declare the spatial limit

        float x = Random.Range(bounds.min.x, bounds.max.x); //random value of x in the limit
        float y = Random.Range(bounds.min.y, bounds.max.y); //random value of y in the limit

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        RandomPos();
    }
}
