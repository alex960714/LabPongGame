using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    private bool ballIsActive;
    private Vector3 ballStartPosition;
    private Rigidbody2D ball;
    private int PlayerPoints;
    private int EnemyPoints;
    private int Level;

	// Use this for initialization
	void Start () {
        ballIsActive = false;
        ballStartPosition = transform.position;
        ball = GetComponent<Rigidbody2D>();
        PlayerPoints = EnemyPoints = 0;
        Level = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            BallStart();
        }

        if (transform.position.x > 8)
        {
            PlayerPoints++;
        }
        else if (transform.position.x < -8)
        {
            EnemyPoints++;
        }

        if (PlayerPoints == 3)
        {
            LoadNextLevel();
            PlayerPoints = EnemyPoints = 0;
            BallFinish();
        }
        else if (EnemyPoints == 3)
        {
            SceneManager.LoadScene("Looser");
        }
    }

    private void LoadNextLevel()
    {
        Level++;
        if (Level < 3)
        {
            SceneManager.LoadScene("Level" + Level.ToString());
        }
        else
        {
            SceneManager.LoadScene("Winner");
        }
    }

    void BallStart()
    {
        if (!ballIsActive)
        {
            ball.isKinematic = false;
            ball.AddForce(GetForce());
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

    Vector2 GetForce()
    {
        return new Vector2(600.0f, 450.0f * UnityEngine.Random.Range(-1.0f, 1.0f));
    }
}
