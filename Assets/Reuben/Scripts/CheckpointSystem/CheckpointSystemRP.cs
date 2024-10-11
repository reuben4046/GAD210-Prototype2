using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystemRP : MonoBehaviour
{

    //the game mode Lives or chekpoint mode
    public bool isInCheckpointMode;
    
    //refernce to the fps controller so that it can be set inactive while it isnt needed. 
    public FirstPersonController firstPersonController;

    //the list of checkpoints (this is populated by each of the checkpoints when the game begins)
    public List<CheckpointRP> checkPointList = new List<CheckpointRP>();

    [SerializeField] private int checkpointsCollected = 0;


    void Start()
    {
        firstPersonController.enabled = false;
    }
    
    //subscribing and unsubscribing to events
    void OnEnable()
    {
        EventsSystemRP.OnResetCheckPoints += ResetCheckPoints;
    }
    void OnDisable()
    {
        EventsSystemRP.OnResetCheckPoints -= ResetCheckPoints;
    }

    //both function are connected to buttons in the menu ui, sets up the game when they are clicked and sets the game mode accordingly
    public void CheckPointMode()
    {   
        isInCheckpointMode = true;
        EventsSystemRP.OnIsInCheckpointMode?.Invoke(isInCheckpointMode);
        EventsSystemRP.OnCloseMenuAndStartGame?.Invoke(true);
        firstPersonController.enabled = true;
    }
    public void LifeSystemMode()
    {
        isInCheckpointMode = false;
        EventsSystemRP.OnIsInCheckpointMode?.Invoke(isInCheckpointMode);
        EventsSystemRP.OnCloseMenuAndStartGame?.Invoke(false);
        firstPersonController.enabled = true;
    }

    //resets all of the checkpoints variables
    void ResetCheckPoints()
    {
        foreach (CheckpointRP checkpoint in checkPointList)
        {
            checkpoint.isCurrentCheckpoint = false;
            checkpoint.checkPointUsed = false;
        }
    }

    //sets the current checkpoint this is called by the checkpoint script every time a new current checkpoint is set. 
    public void GetCurrentCheckpoint(CheckpointRP checkpoint)
    {
        checkpointsCollected++;
        Debug.Log("Checkpoints collected: " + checkpointsCollected);
        EventsSystemRP.OnGetCurrentCheckpoint?.Invoke(checkpoint);
        EventsSystemRP.OnGetCheckPoints?.Invoke(checkpointsCollected);
        if (checkpoint.lastCheckpoint == true)
        {
            EventsSystemRP.OnLastCheckpointReached?.Invoke();
        }
    }
}
