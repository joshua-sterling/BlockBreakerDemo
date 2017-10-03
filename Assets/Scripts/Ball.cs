using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    private Paddle paddle;                           //paddle

    private Vector3 paddleToBallVector;             //destination (ball) minus the paddle's transform
    private bool hasStarted = false;                //has the game started

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;  //game not started, lock ball to paddle

            if (Input.GetMouseButtonDown(0))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 11f);           //when mouse is clicked, launch ball
                print("Mouse clicky, ball launchy");
                hasStarted = true;                                                          //and start game
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
            print(tweak);
        }
    }
}
