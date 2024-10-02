using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSytem : MonoBehaviour
{
    public Transform spawnPoint;
    public int health;

    public GameObject ground;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            health--;
            if (health !<= 0)
            {
                BackToCheckPoint();
            }
            else { BackToStart(); }
        }
    }

    void BackToStart()
    {
        transform.position = spawnPoint.position;
    }

    void BackToCheckPoint()
    {

    }

    Transform GetLastCheckPoint()
    {

        return null;
    }
}
