using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MovingObject : MonoBehaviour
{

    [Title ("Settings")]
    public Direction direction;
    public enum Direction
    {
        X,
        Y,
        Z
    }
    public bool switchDirection;

    private Vector3 moveDirection;
    public float moveAmount;
    public float moveSpeed;
    public float stopTime;

    Vector3 startPosition;


    void Start()
    {
        switch (direction)
        {
            case Direction.X:
                    moveDirection = new Vector3(1, 0, 0);
                break;
            case Direction.Y:
                    moveDirection = new Vector3(0, 1, 0);
                break;
            case Direction.Z:
                moveDirection = new Vector3(0, 0, 1);
                break;
            default:
                break;
        }

        startPosition = transform.position;

        StartCoroutine(MoveObjectCoroutine());
    }

    bool forward;
    IEnumerator MoveObjectCoroutine()
    {
        while (true)
        {
            switch (forward)
            {
                case true:
                {
                    transform.position += moveDirection * moveSpeed * Time.deltaTime;
                    if (Vector3.Distance(transform.position, startPosition) >= moveAmount)
                    {                     
                        yield return new WaitForSeconds(stopTime);
                        startPosition = transform.position;
                        forward = false;
                    }
                    break;
                }
                case false:
                {
                    transform.position -= moveDirection * moveSpeed * Time.deltaTime;
                    if (Vector3.Distance(transform.position, startPosition) <= moveAmount)
                    {
                        yield return new WaitForSeconds(stopTime);
                        startPosition = transform.position;
                        forward = true;
                    }
                    break;
                }
            }
        }
    }

}
