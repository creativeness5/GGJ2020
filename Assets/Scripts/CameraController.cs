using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera mainCamera;

    public float speed;
    public float zoomSpeed;
    public float zoomTarget;
    public float lastScrollWheelDirection;

    private float ScrollWheel
    {
        get { return Input.GetAxis("Mouse ScrollWheel"); }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }


        //Scrollwheel from https://stackoverflow.com/users/4820436/ben-rubin 

        if ((this.lastScrollWheelDirection > 0 && this.ScrollWheel < 0) ||
            (this.lastScrollWheelDirection < 0 && this.ScrollWheel > 0))
        {
            this.zoomTarget = 0;
        }

        if (this.ScrollWheel != 0)
        {
            this.lastScrollWheelDirection = this.ScrollWheel;
        }

        // zoomTarget is the total distance that is remaining to be zoomed.
        // Each frame that the scroll wheel is moved, we'll add a little more
        // to the distance that we want to zoom
        zoomTarget += this.ScrollWheel * this.zoomSpeed;

        // zoomTime is used to do linear interpolation to create a smooth zoom.
        // Each time the player moves the mouse wheel, we reset zoomTime so that 
        // we restart our linear interpolation
        if (this.ScrollWheel != 0)
        {
            //   // this.zoomSpeed = 0;
        }

        if (this.zoomTarget != 0)
        {
            this.zoomSpeed += Time.deltaTime;

            // Calculate how much our camera will be moved this frame using linear
            // interpolation.  You can adjust how fast the camera zooms by
            // changing the divisor for zoomTime
            var translation = Vector3.Lerp(
                new Vector3(0, 0, 0),
                new Vector3(0, this.zoomTarget, 0),
                zoomSpeed / 4f); // see comment above

            // Zoom the camera by the amount that we calculated for this frame
            this.transform.position -= translation;

            // Decrease the amount that's remaining to be zoomed by the amount 
            // that we zoomed this frame
            this.zoomTarget -= translation.y;
        }
    }
}
