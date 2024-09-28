using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class MovingObject : MonoBehaviour
{
    [Title ("Settings")]
    public MoveAxis axis;
    public enum MoveAxis
    {
        X,
        Y,
        Z
    }
    
    public MoveDirection direction;
    public enum MoveDirection
    {
        Positive,
        Negative
    }

    private Vector3 moveAxis;
    public float moveAmount;
    public float moveSpeed;

    Vector3 startPosition;

    [Button]
    public void UpdateSettings()
    {
        startPosition = transform.position;
    }

    void OnValidate()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        DirectionSwitcher();
        
        Vector3 v = startPosition;
        v += moveAmount * Mathf.Sin(Time.time * moveSpeed) * moveAxis;
        transform.position = v;
    }

    void DirectionSwitcher()
    {
        switch (axis)
        {
            case MoveAxis.X:
                    moveAxis = new Vector3(1, 0, 0);
                break;
            case MoveAxis.Y:
                    moveAxis = new Vector3(0, 1, 0);
                break;
            case MoveAxis.Z:
                moveAxis = new Vector3(0, 0, 1);
                break;
        }
        switch (direction)
        {
            case MoveDirection.Positive:
                moveAxis *= 1;
                break;
            case MoveDirection.Negative:
                moveAxis *= -1;
                break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        switch (axis)
        {
            case MoveAxis.X:
                Gizmos.DrawLine(startPosition + new Vector3(moveAmount, 0, 0), startPosition + new Vector3(-moveAmount, 0, 0));
                break;
            case MoveAxis.Y:
                Gizmos.DrawLine(startPosition + new Vector3(0, moveAmount, 0), startPosition + new Vector3(0, -moveAmount, 0));
                break;
            case MoveAxis.Z:
                Gizmos.DrawLine(startPosition + new Vector3(0, 0, moveAmount), startPosition + new Vector3(0, 0, -moveAmount));
                break;
        }
    }

}
