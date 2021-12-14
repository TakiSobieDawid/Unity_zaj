using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningLeft = false;
    private bool isRunningRight = false;
    private float RightPosition;
    private float LeftPosition;

    void Start()
    {
        LeftPosition = transform.position.x ;
        RightPosition = transform.position.x + distance;
    }

    void Update()
    {
        if (transform.position.x >= RightPosition)
        {
            isRunningLeft = true;
            isRunningRight = false;
            elevatorSpeed = -elevatorSpeed;
            isRunning = true;
        }
        if (isRunningRight && transform.position.x >= RightPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.x <= LeftPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            other.gameObject.transform.parent=transform;
            if (transform.position.x <= LeftPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            
            isRunning = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.parent=transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent=null;
        }
    }
}
