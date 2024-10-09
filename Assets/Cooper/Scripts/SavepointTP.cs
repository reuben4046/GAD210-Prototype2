using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavepointTP : MonoBehaviour
{

    [SerializeField] private Vector3 currentLifeSysytem;
    [SerializeField] private Vector3 currentCheckpoint;
    [SerializeField] private bool switched = false;
    [SerializeField] private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           if (!switched)
           {
                transform.position = currentCheckpoint;
            }
           else
           {
                transform.position = currentLifeSysytem;
                lives--;
                Debug.Log($"{lives} left");
           }           
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!switched) 
            {
                switched = true;
                Debug.Log($"Lives enabled");
            }
            else
            {
                switched = false;
                Debug.Log($"Checkpoints enabled");
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!switched)
        {
            if (other.tag == "CheckPoint" || other.tag == "BothPoints")
            {
                Debug.Log($"Check point hit");
                Debug.Log("Hit Checkpoint");
                currentCheckpoint = other.transform.position;
                currentCheckpoint.y += 1;
                other.tag = "UsedPoint";
            }
        }
        else
        {
            if (other.tag == "LifeSystem" || other.tag == "BothPoints")
            {
                Debug.Log($"Life save hit");
                currentLifeSysytem = other.transform.position;
                currentLifeSysytem.y += 1;
                other.tag = "UsedPoint";
            }
        }      
    }

}