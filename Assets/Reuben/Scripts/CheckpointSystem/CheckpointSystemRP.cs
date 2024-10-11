using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystemRP : MonoBehaviour
{
    public bool isInCheckpointMode;

    public GameObject menu;

    public FirstPersonController firstPersonController;

    public List<CheckpointRP> checkPointList = new List<CheckpointRP>();

    void Start()
    {
        firstPersonController.enabled = false;
    }
    public void CheckPointMode()
    {   
        isInCheckpointMode = true;
        EventsSystemRP.OnIsInCheckpointMode?.Invoke(isInCheckpointMode);
        menu.SetActive(false);
        firstPersonController.enabled = true;
    }
    public void LifeSystemMode()
    {
        isInCheckpointMode = false;
        EventsSystemRP.OnIsInCheckpointMode?.Invoke(isInCheckpointMode);
        menu.SetActive(false);
        firstPersonController.enabled = true;
    }



    void OnEnable()
    {
        EventsSystemRP.OnResetCheckPoints += ResetCheckPoints;
    }

    void OnDisable()
    {
        EventsSystemRP.OnResetCheckPoints -= ResetCheckPoints;
    }

    void ResetCheckPoints()
    {
        foreach (CheckpointRP checkpoint in checkPointList)
        {
            checkpoint.isCurrentCheckpoint = false;
            checkpoint.checkPointUsed = false;
        }
    }

    public void GetCurrentCheckpoint(CheckpointRP checkpoint)
    {
        EventsSystemRP.OnGetCurrentCheckpoint?.Invoke(checkpoint);
    }
}
