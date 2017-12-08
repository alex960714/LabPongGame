using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallLevel1 : BallLevel {
    
	// Update is called once per frame
	public override void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            BallStart();
        }

        if (transform.position.x > 8)
        {
            PlayerPoints++;
            PlayerSide.text = "Player  " + PlayerPoints.ToString();
            BallFinish();
        }
        else if (transform.position.x < -8)
        {
            EnemyPoints++;
            EnemySide.text = EnemyPoints.ToString() + "  Computer";
            BallFinish();
        }

        if (PlayerPoints == 3)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (EnemyPoints == 3)
        {
            SceneManager.LoadScene("Looser");
        }
    }
    
    public override void BallStart()
    {
        if (!ballIsActive)
        {
            ball.isKinematic = false;
            ball.WakeUp();
            ball.AddForce(new Vector2(400.0f, UnityEngine.Random.Range(-1.0f, 1.0f) > 0 ? 300.0f : -300.0f));
            ballIsActive = true;
        }
    }
}
