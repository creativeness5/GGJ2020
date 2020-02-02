using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{

    private Rigidbody rb;
    
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision colli)
    {
        if (colli.gameObject.CompareTag("Material"))
        {
            count = count + 2;
        }

        if (colli.gameObject.CompareTag("Dome"))
        {
            count = count - 2;
        }
    }

    
}
