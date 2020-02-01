using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class droneBehavior : MonoBehaviour
{
    private Transform tf;
    public Transform[] waypoints; // we have only 1 waypoint that is the gather button
    public float turnSpeed = 0.5f;
    public float moveSpeed = 0.5f;
    private int currentWaypoint = 0;
    public float close = 1.0f;
    public float droneNumber = 1; // 1 for Scout, 2 for Scavenge
    private Vector3 targetPosition;
    public GameObject dome;
    private Transform dometf;

    private float moveCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        tf = GetComponent<Transform>(); // getting Transform component
        dometf = dome.GetComponent<Transform>();
    }

    public void resetMove()
    {
        moveCount = 0; // resets counter on button press
        
    }

    public bool RotateTowards(Vector3 target, float speed) { 
        Vector3 vectorToTarget;
        vectorToTarget = target - tf.position;
        UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(vectorToTarget);

        if (targetRotation == tf.rotation)
        {
            return false;
        }

        tf.rotation = UnityEngine.Quaternion.RotateTowards(tf.rotation, targetRotation, speed * Time.deltaTime);
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (moveCount < 180)
        {
            if (droneNumber <= 1)
            {
                //if scout drone
                tf.position += (tf.forward * moveSpeed); // Moves Drone Forward
                    tf.Rotate(0, turnSpeed, 0); // Creates circle motion
                    moveCount++; // adds counter to reach limit

                    ;
            }
            else if (droneNumber > 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit)) {
                            targetPosition = hit.point;
                            waypoints[0].position = targetPosition;
                    }
                }

                if (RotateTowards(waypoints[currentWaypoint].position, turnSpeed))
                {
                    //nothing
                }
                else
                {
                    tf.position += (tf.forward * moveSpeed);
                    moveCount++;
                }

                if (Vector3.SqrMagnitude(waypoints[currentWaypoint].position - tf.position) < (close * close))
                { 

                    waypoints[0].position = Vector3.zero;
                }
            }
        }
    }
}
