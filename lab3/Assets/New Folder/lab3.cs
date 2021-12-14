using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab3 : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    Vector3 stop;
    int Direction = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = rb.position + new Vector3(0, 0, -10);
    }
    void FixedUpdate()
    {
        Vector3 velocity= new Vector3(0, 0, 0);
        if (Direction == 1)
        {
            velocity = new Vector3(0, 0, -1);
            velocity = velocity.normalized * speed * Time.deltaTime;
            if(Vector3.Distance(rb.position, stop) <= 1)
            {
                Direction=2;
                stop=rb.position+new Vector3(-10,0,0);
                transform.Rotate(0,90,0);
            }
             rb.MovePosition(transform.position + velocity);
        }
        else if(Direction == 2 )
        {
            velocity = new Vector3(-1, 0, 0);
            velocity = velocity.normalized * speed * Time.deltaTime;
            if(Vector3.Distance(rb.position, stop) <= 1)
            {
                Direction=3;
                stop=rb.position+new Vector3(0,0,10);
                transform.Rotate(0,90,0);
            }
             rb.MovePosition(transform.position + velocity);
        }
        else if(Direction == 3 )
        {
            velocity = new Vector3(0, 0, 1);
            velocity = velocity.normalized * speed * Time.deltaTime;
            if(Vector3.Distance(rb.position, stop) <= 1)
            {
                Direction=4;
                stop=rb.position+new Vector3(10,0,0);
                transform.Rotate(0,90,0);
            }
             rb.MovePosition(transform.position + velocity);
        }

        else if(Direction == 4 )
        {
            velocity = new Vector3(1, 0, 0);
            velocity = velocity.normalized * speed * Time.deltaTime;
            if(Vector3.Distance(rb.position, stop) <= 1)
            {
                Direction=1;
                stop=rb.position+new Vector3(0,0,-10);
                transform.Rotate(0,90,0);
            }
             rb.MovePosition(transform.position + velocity);
        }

       
    }
}