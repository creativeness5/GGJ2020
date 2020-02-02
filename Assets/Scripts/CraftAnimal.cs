using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftAnimal : MonoBehaviour
{
    Ray ray;
    public GameObject gameManager;
    RaycastHit hit;
    public GameObject Animal;
    public bool SpawningAnimal = false;
    private float anumber = 1.0f;

    public void SpawnAnimalCoroutine()
    {
        SpawningAnimal = true;
    }

    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.Log("weee");

        if (Input.GetKey(KeyCode.Mouse1))
        {
            SpawningAnimal = false;
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(Animal, new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity) as GameObject;
                gameManager.GetComponent<Inventory>().Materials -= 2;
                SpawningAnimal = false;
            }
        }
        else
        {
            
        }
    }
}
