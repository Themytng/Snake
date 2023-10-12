using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    //variable
    private Vector2 direction; //direction control

    List<Transform> segments; //variable to store all body parts
    public Transform bodyPrefab;   //variable to store the body

    public bool goingUp;
    public bool goingDown;
    public bool goingLeft;
    public bool goingRight;


    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);        //add snake head to list
    }

    // Update is called once per frame
    void Update()
    {
        //snake movement
        if (Input.GetKeyDown(KeyCode.W)) //when W is pressed
        {
            direction = Vector2.up; //go up
            goingUp = true;
            goingDown = false;
            goingLeft = false;
            goingRight = false;
        }

        else if (Input.GetKeyDown(KeyCode.A)) //when A is pressed
        {
            direction = Vector2.left;   //go left
            goingUp = false;
            goingDown = false;
            goingLeft = true;
            goingRight = false;
        }

        else if (Input.GetKeyDown(KeyCode.S)) //when S is pressed
        {
            direction = Vector2.down; //go down
            goingUp = false;
            goingDown = true;
            goingLeft = false;
            goingRight=false;
        }

        else if (Input.GetKeyDown(KeyCode.D)) // when D is pressed
        {
            direction = Vector2.right; // go right
            goingUp = false;
            goingDown = false;
            goingLeft = false;
            goingRight = true;
        }
    }

    //FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        //move snake body
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }



        this.transform.position = new Vector2(                     //get the position
            Mathf.Round(this.transform.position.x) + direction.x,  //round the number add value to X
            Mathf.Round(this.transform.position.y) + direction.y   //round the number add value to y
            );
    }

    //Function for Snake growth
    void Grow()
    {
        Transform segment = Instantiate(this.bodyPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    //Function for Collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }

        else if (other.tag == "Obstacle") //check if the other obje
        {
            SceneManager.LoadScene("EndScene"); //change to the end scene
        }
    }
}
