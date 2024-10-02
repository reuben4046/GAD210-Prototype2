using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavepointTP : MonoBehaviour
{

    [SerializeField] private Vector3 currentSavepoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = currentSavepoint;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<CheckpointTwo> ().enabled = true;
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SavePoint" || other.tag == "BothPoints")
        {
            currentSavepoint = other.transform.position;
            currentSavepoint.y += 1;
        }
        other.tag = "UsedPoint";
    }
}
