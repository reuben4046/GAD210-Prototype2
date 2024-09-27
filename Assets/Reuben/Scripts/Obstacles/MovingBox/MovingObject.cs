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

    private Vector3 moveDirection;
    public float moveAmount;
    public float moveSpeed;

    Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        DirectionSwitcher();
        
        Vector3 v = startPosition;
        v += moveAmount * Mathf.Sin(Time.time * moveSpeed) * moveDirection;
        transform.position = v;
    }

    void DirectionSwitcher()
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
        }
    }

}
