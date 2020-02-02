using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneBehavior : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 0.5f;
    public float moveSpeed = 0.5f;

    private float moveCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>(); // getting Transform component
    }

    public void resetMove()
    {
        moveCount = 0; // resets counter on button press
    }
    // Update is called once per frame
    void Update()
    {
        if (moveCount < 180) // Limits movement per turn
        {
            tf.position = tf.position + (tf.forward * moveSpeed); // Moves Drone Forward
            tf.Rotate(0, turnSpeed, 0); // Creates circle motion
            moveCount++; // adds counter to reach limit
        };
    }
}
