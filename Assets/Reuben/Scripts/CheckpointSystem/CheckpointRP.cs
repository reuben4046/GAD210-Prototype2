using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRP : MonoBehaviour
{   
    //variables for the checkpoint
    public bool isCheckpoint = false;
    public bool checkPointUsed = false;
    public bool isCurrentCheckpoint = false;

    //reference to the checkpoint system
    public CheckpointSystemRP checkpointSystem;

    //gets checkpoint system script and then adds this checkpoint to the list in that checkpointSystem class
    private void Start()
    {
        checkpointSystem = GameObject.Find("CheckpointSystem").GetComponent<CheckpointSystemRP>();

        checkpointSystem.checkPointList.Add(this);
    }

    void OnTriggerEnter(Collider other)
    {
        //shuts down the function straight away if the trigger is not a player
        if (!other.gameObject.CompareTag("Player") || checkPointUsed)
        {
            return;
        }
        //called if in checkpoint mode and if the checkpoint has the isCheckpoint variable set to true
        if (checkpointSystem.isInCheckpointMode && isCheckpoint)
        {
            //sets the all the checkpoints to not be the current checkpoint and then sets the checkpoint that has just been entered to the current checkpoint 
            foreach (CheckpointRP checkpoint in checkpointSystem.checkPointList)
            {
                checkpoint.isCurrentCheckpoint = false;
            }
            isCurrentCheckpoint = true;
            checkpointSystem.GetCurrentCheckpoint(this);
            checkPointUsed = true; //sets the checkpoint used to true so that it can't be used again
        }
        //called if not in checkpoint mode only difference is that every checkpoint workes now instead of the ones that have the isCheckpoint variable set to true
        if (!checkpointSystem.isInCheckpointMode)
        {
            foreach (CheckpointRP checkpoint in checkpointSystem.checkPointList)
            {
                checkpoint.isCurrentCheckpoint = false;
            }
            isCurrentCheckpoint = true;
            checkpointSystem.GetCurrentCheckpoint(this);
            checkPointUsed = true;
        }
    }


    //draws a cube at the checkpoint sets colours based on if the isCheckpoint variable is true or false
    void OnDrawGizmos()
    {
        if (!isCheckpoint)
        {
            Gizmos.color = Color.red;
        } else 
        {
            Gizmos.color = Color.green;
        }
        
        Gizmos.DrawWireCube(transform.position, new Vector3(6f, 4f, 6f));
    }
}
