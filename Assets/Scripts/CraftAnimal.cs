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

    public void SpawnAnimalCoroutine()
    {
        SpawningAnimal = true;
    }

    public void Update()
    {
        if (SpawningAnimal == false)
        {
            return;
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Fog")
            {
                Debug.Log("Foghit");
                return;
            }
        }

        Debug.Log("weee");

        if (Input.GetMouseButtonDown(1))
        {
            SpawningAnimal = false;
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.collider.gameObject.tag);
                GameObject obj = Instantiate(Animal, new Vector3(hit.point.x, 1.1f, hit.point.z), Quaternion.identity) as GameObject;
                gameManager.GetComponent<Inventory>().Materials -= 3;
                SpawningAnimal = false;
            }
        }
        else
        {
            
        }
    }
}
