using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTwo : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<SavepointTP>().enabled = true;
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Hit {other.tag}");
        if (other.tag == "CheckPoint" || other.tag == "BothPoints")
        {
            Debug.Log("Hit Checkpoint");
            currentCheckpoint = other.transform.position;
            currentCheckpoint.y += 1;
        }
        other.tag = "UsedPoint";
    }
}
