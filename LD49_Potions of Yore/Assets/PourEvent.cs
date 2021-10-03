using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourEvent : MonoBehaviour
{
    [SerializeField] GameObject paddle;

    bool down;

    private void OnMouseDown()
    {
        Debug.Log("Down");
        down = true;
    }

    private void OnMouseUp()
    {
        Debug.Log("up");
        down = false;
    }

    private void Update()
    {
        if (down)
        {
            targetAngle = new Vector3(0f, 0f, 90f);
        }
        else
        {
            targetAngle = new Vector3(0f, 0f, 0f);
        }

        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * speed),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * speed),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * speed));

        paddle.transform.eulerAngles = currentAngle;
    }


    public Vector3 targetAngle = new Vector3(0f, 0f, 90f);

    private Vector3 currentAngle;

    private float speed = 6;

    public void Start()
    {
        currentAngle = paddle.transform.eulerAngles;
    }
}
