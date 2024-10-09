using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSytem : MonoBehaviour
{
    public Transform spawnPoint;
    public int health;
    public SavepointTP savePointTP;

    public GameObject ground;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            health--;
            Debug.Log($"{health} lives left");
            if (health > 0)
            {
                BackToCheckPoint();
            }
            else { BackToStart(); health = 3; }
        }
    }

    void BackToStart()
    {
        transform.position = spawnPoint.position;
    }

    void BackToCheckPoint()
    {
        if (!savePointTP.switched)
        {
            transform.position = savePointTP.currentCheckpoint;
        }
        else
        {
            transform.position = savePointTP.currentLifeSysytem;
        }
    }

    /*Transform GetLastCheckPoint()
    {

        return null;
    } */
}
