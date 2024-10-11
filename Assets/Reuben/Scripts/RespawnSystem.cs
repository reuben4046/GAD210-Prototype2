using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public Transform spawnPoint;
    public int health;

    public CheckpointSystemRP checkpointSystem;

    bool isInCheckpointMode;

    [SerializeField] private CheckpointRP currentCheckpoint;
    public GameObject ground;

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

    void GetCurrentCheckpoint(CheckpointRP checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    void IsCheckPointMode(bool mode)
    {
        isInCheckpointMode = mode;
    }
    
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

    void BackToStart()
    {
        EventsSystemRP.OnResetCheckPoints?.Invoke();
        transform.position = spawnPoint.position;
    }

    void BackToCheckPoint()
    {
        transform.position = currentCheckpoint.transform.position;
    }
}
