using UnityEngine;
using UnityEngine.UI;

public abstract class BallLevel : MonoBehaviour {
    protected bool ballIsActive;
    protected Vector3 ballStartPosition;
    protected Rigidbody2D ball;
    protected int PlayerPoints;
    protected int EnemyPoints;
    public Text PlayerSide;
    public Text EnemySide;

    // Use this for initialization
    public void Start()
    {
        ballIsActive = false;
        ballStartPosition = transform.position;
        ball = GetComponent<Rigidbody2D>();
        PlayerPoints = EnemyPoints = 0;
    }

    // Update is called once per frame
    public abstract void Update();
    public abstract void BallStart();

    public void BallFinish()
    {
        if (ballIsActive)
        {
            ball.isKinematic = true;
            transform.position = ballStartPosition;
            ball.Sleep();
            ballIsActive = false;
        }
    }
}
