using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float bounceWaitTime;
    [SerializeField] private float bounceStopTime;
    [SerializeField] private float bounceForce;

    bool bouncing = false;

    Vector3 savedPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        savedPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(StartBounce());
        }
    }

    IEnumerator StartBounce()
    {
        yield return new WaitForSeconds(bounceWaitTime);
        bouncing = true;
    }

    void Update()
    {
        if (bouncing)
        {
            Bounce();
            bouncing = false;
        }
        else
        {
            ResetPosition();
        }
    }

    void Bounce()
    {
        rb.AddForce(new Vector3(0, bounceForce, 0), ForceMode.Impulse);
    }

    void ResetPosition()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = savedPosition;
    }
}
