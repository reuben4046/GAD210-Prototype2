using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayerHolder : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Transform>().parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Transform>().parent = null;
        }
    }
}
