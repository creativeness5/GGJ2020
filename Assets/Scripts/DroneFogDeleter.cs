using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFogDeleter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fog")
        {
            Destroy(collision.gameObject);
        }
    }
}
