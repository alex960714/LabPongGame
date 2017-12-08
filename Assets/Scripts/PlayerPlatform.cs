using UnityEngine;

public class PlayerPlatform : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private float Yboundary = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnMouseDown();
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Moved:
                    OnMouseDrag();
                    break;
            }
        }
	}

    private void OnMouseDown()
    {
        Vector3 position = Vector3.zero;

        if (Input.touchCount > 0)
        {
            position = new Vector3(Input.touches[0].position.x, 
                Input.touches[0].position.y, 0);
        }
        else
        {
            position = Input.mousePosition;
        }

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, position.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 position = Vector3.zero;

        if (Input.touchCount > 0)
        {
            position = new Vector3(Input.touches[0].position.x,
                Input.touches[0].position.y, 0);
        }
        else
        {
            position = Input.mousePosition;
        }
        curScreenPoint = new Vector3(screenPoint.x, position.y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        if (transform.position.y < -Yboundary + transform.localScale.y / 2)
        {
            transform.position = new Vector3(transform.position.x,
                -Yboundary + transform.localScale.y / 2, transform.position.z);
        }
        if (transform.position.y > Yboundary - transform.localScale.y / 2)
        {
            transform.position = new Vector3(transform.position.x,
                Yboundary - transform.localScale.y / 2, transform.position.z);
        }
    }
}
