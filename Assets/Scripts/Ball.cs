using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private bool ballIsActive;
    private Vector3 ballStartPosition;
    private Vector2 ballInitialForce;
    private Rigidbody2D ball;

	// Use this for initialization
	void Start () {
        ballInitialForce = new Vector2(400.0f, Random.Range(-1.0f, 1.0f) > 0 ? 300.0f : -300.0f);
        ballIsActive = false;
        ballStartPosition = transform.position;
        ball = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            BallStart();
        }
        if ((transform.position.x > 12) || (transform.position.x < -12))
        {
            BallFinish();
        }
	}

    void BallStart()
    {
        if (!ballIsActive)
        {
            ball.isKinematic = false;
            ball.AddForce(ballInitialForce);
            ballIsActive = true;
        }
    }

    void BallFinish()
    {
        if (ballIsActive)
        {
            ball.isKinematic = true;
            transform.position = ballStartPosition;
            ballIsActive = false;
        }
    }
}
