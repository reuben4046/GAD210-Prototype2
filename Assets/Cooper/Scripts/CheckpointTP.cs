using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointTP : MonoBehaviour
{
    [SerializeField] private Vector3 currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = currentCheckpoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPoint") 
        { 
            currentCheckpoint = other.transform.position;
            currentCheckpoint.y += 1;
        }
        other.tag = "UsedPoint";
    }
}
