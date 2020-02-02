using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerDrone : MonoBehaviour
{
    private Transform tf;
    public Transform[] waypoints; // we have only 1 waypoint that is the gather button
    public float turnSpeed = 0.5f;
    public float moveSpeed = 0.5f;
    public float close = 0.25f;
    private Vector3 targetPosition;

    private int dronePhase = 0;

    // Start is called before the first frame update
    void Awake()
    {
        tf = GetComponent<Transform>(); // getting Transform component
    }

    public void resetMove()
    {
        if (dronePhase < 4)
        {
            dronePhase++; // resets counter on button press
            turnSpeed = 50;
        }
        else
        {
            dronePhase = 0;
        }
    }

    public bool RotateTowards(Vector3 target, float speed)
    {
        //Rotation for drones to face waypoint
        Vector3 vectorToTarget;
        vectorToTarget = target - tf.position;
        UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(vectorToTarget);

        if (targetRotation == tf.rotation)
        {
            return false;
        }
        // Need to stop constant rotation when at waypoint.

        tf.rotation = UnityEngine.Quaternion.RotateTowards(tf.rotation, targetRotation, speed * Time.deltaTime);
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dronePhase == 0)
        {
            if (Input.GetMouseButtonDown(1)) // Base for button press on waypoint to gather resourses.
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    targetPosition = hit.point;
                    waypoints[1].position = targetPosition;
                    Debug.Log("waypoint set");
                }
            }
        }

        if (dronePhase == 1)
        {
            if (RotateTowards(waypoints[1].position, turnSpeed)) // Rotate towards waypoint
            {
                //nothing
            }
            else
            {
                tf.position += (tf.forward * moveSpeed);

            }

            if (Vector3.SqrMagnitude(waypoints[1].position - tf.position) < (close * close)
            ) // reaches waypoint  
            {
                

                turnSpeed = 0;
            }
        }

        if (dronePhase == 2)
        {
            if (RotateTowards(waypoints[0].position, turnSpeed)) // Rotate towards waypoint
            {
                //nothing
            }
            else
            {
                tf.position += (tf.forward * moveSpeed);

            }

            if (Vector3.SqrMagnitude(waypoints[0].position - tf.position) < (close * close)
            ) // reaches waypoint  
            {

                turnSpeed = 0;
            }
        }

        if (dronePhase == 3)
        {
            if (RotateTowards(waypoints[1].position, turnSpeed)) // Rotate towards waypoint
            {
                //nothing
            }
            else
            {
                tf.position += (tf.forward * moveSpeed);

            }

            if (Vector3.SqrMagnitude(waypoints[1].position - tf.position) < (close * close)
            ) // reaches waypoint  
            {
                turnSpeed = 0;
            }
        }
        if (dronePhase == 4)
        {
            if (RotateTowards(waypoints[0].position, turnSpeed)) // Rotate towards waypoint
            {
                //nothing
            }
            else
            {
                tf.position += (tf.forward * moveSpeed);

            }

            if (Vector3.SqrMagnitude(waypoints[0].position - tf.position) < (close * close)
            ) // reaches waypoint  
            {

                turnSpeed = 0;
            }
        }
    }
}