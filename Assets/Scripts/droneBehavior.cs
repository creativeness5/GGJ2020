using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class droneBehavior : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 0f;
    public float moveSpeed = 0f;
    public float initalMove = 0.05f;
    int turnToMove = -1;
    public int turnCount = 5;
    private float moveCount = 0f;
    private int rotateBack = 0;
    private float rotateCount = 0f;
    // Start is called before the first frame update
    void Awake()
    { 
        tf = GetComponent<Transform>(); // getting Transform component
    }

    public void resetMove()
    {
        moveCount = 0;
        rotateBack = 0; // resets counter on button press
        
        if (turnToMove < 4)
        {
            turnToMove++;
        }
        else
        {
            Debug.Log("resetScouts");
            turnToMove = 0;
            rotateCount = 0;
            rotateBack = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount < 180) // Limits movement per turn
        {
            if (turnToMove < 0)
            {
                moveSpeed = 0;
                turnSpeed = 0;
            }
            if (turnToMove == 0)
            {
                if (rotateCount < 180)
                {
                    tf.Rotate(0, 0.5f, 0);
                    rotateCount++;
                }
                else
                {
                    tf.position += (tf.forward * initalMove);
                    moveCount++;
                }
            }
            else
            {


                tf.position += (tf.forward * moveSpeed); // Moves Drone Forward
                tf.Rotate(0, turnSpeed, 0); // Creates circle motion
                moveCount++; // adds counter to reach limit
            }
        }
        else if (rotateBack < 180 && turnToMove == 0)
        {
            tf.Rotate(0, -0.5f, 0);
            rotateBack++;

        }
        else if (rotateBack == 180)
        {
            turnSpeed = -0.5f;
            moveSpeed += 0.1f;
            rotateBack++;
        }
    }
}
