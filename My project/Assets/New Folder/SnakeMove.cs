using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    //variable
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //when W is pressed
        {
            direction = Vector2.up;      //go up
        }

        else if (Input.GetKeyDown(KeyCode.A)) //when A is pressed
        {
            direction = Vector2.left;   //go left
        }

        else if (Input.GetKeyDown(KeyCode.S)) //when S is pressed
        {
            direction = Vector2.down; //go down
        }

        else if (Input.GetKeyDown(KeyCode.D)) // when D is pressed
        {
            direction = Vector2.right; // go right
        }
    }

    //FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        this.transform.position = new Vector2(                     //get the position
            Mathf.Round(this.transform.position.x) + direction.x,  //round the number add value to X
            Mathf.Round(this.transform.position.y) + direction.y   //round the number add value to y
            );
    }
}
