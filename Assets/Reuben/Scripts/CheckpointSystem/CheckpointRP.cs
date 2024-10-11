using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRP : MonoBehaviour
{
    public bool isCheckpoint = false;
    public bool checkPointUsed = false;

    public bool isCurrentCheckpoint = false;

    public CheckpointSystemRP checkpointSystem;

    private void Start()
    {
        checkpointSystem = GameObject.Find("CheckpointSystem").GetComponent<CheckpointSystemRP>();

        checkpointSystem.checkPointList.Add(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || checkPointUsed)
        {
            return;
        }
        if (checkpointSystem.isInCheckpointMode && isCheckpoint)
        {
            foreach (CheckpointRP checkpoint in checkpointSystem.checkPointList)
            {
                checkpoint.isCurrentCheckpoint = false;
            }
            isCurrentCheckpoint = true;
            checkpointSystem.GetCurrentCheckpoint(this);
            checkPointUsed = true;
        }
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
