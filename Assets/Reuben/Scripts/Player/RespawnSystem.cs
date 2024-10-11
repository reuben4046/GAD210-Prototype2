using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    //starting position for when player runs out of lifes
    public Transform spawnPoint;
    public int health;
    public GameObject ground;

    //checks if the game mode is in checkpoint mode or not. gets set through an event
    bool isInCheckpointMode;

    //set through an event- gets set to current checkpoint from checkpoint system class
    private CheckpointRP currentCheckpoint;

    //subscriving and unsubscribing from events in this script
    void OnEnable()
    {
        EventsSystemRP.OnGetCurrentCheckpoint += GetCurrentCheckpoint;
        EventsSystemRP.OnIsInCheckpointMode += IsCheckPointMode;
    }

    void OnDisable()
    {
        EventsSystemRP.OnGetCurrentCheckpoint -= GetCurrentCheckpoint;
        EventsSystemRP.OnIsInCheckpointMode -= IsCheckPointMode;
    }

    //gets current checkpoint from checkpoint system
    void GetCurrentCheckpoint(CheckpointRP checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    //checks if the game mode is in checkpoint mode so the oncollision enter script can behave accordingly 
    void IsCheckPointMode(bool mode)
    {
        isInCheckpointMode = mode;
    }
    
    //checks if player collides with ground and then depending on what game mode is true calles the corresponding method
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != ground)
        {
            return;
        }
        if (!isInCheckpointMode)
        {
            health--;
            Debug.Log($"{health} lives left");
            if (health > 0)
            {
                BackToCheckPoint();
            }
            else { BackToStart(); health = 3; }
        }
        if (isInCheckpointMode)
        {
            BackToCheckPoint();
        }
    }
    //sets checkpoint back to start position and calls event that resets all of the checkpoints variables
    void BackToStart()
    {
        EventsSystemRP.OnResetCheckPoints?.Invoke();
        transform.position = spawnPoint.position;
    }

    //sets players pos back to the current checkpoint
    void BackToCheckPoint()
    {
        transform.position = currentCheckpoint.transform.position;
    }
}
