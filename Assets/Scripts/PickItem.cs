using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{

    public string itemName = "Material";
    public string itemName1 = "Production";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void PickingItem()
    {
        Destroy(gameObject);
    }
}
