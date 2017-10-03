using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    float mousePosInBlocks;
    public bool autoplay = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!autoplay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.83f, 15.18f);

        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, 0.83f, 15.18f);

        this.transform.position = paddlePos;

    }

}
