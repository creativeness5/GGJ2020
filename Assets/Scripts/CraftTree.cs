using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTree : MonoBehaviour
{
    Ray ray;
    public GameObject gameManager;
    RaycastHit hit;
    public GameObject Tree;
    public bool SpawningTree = false;

    public void SpawnTreeCoroutine()
    {
        SpawningTree = true;
    }

    public void Update()
    {
        if (SpawningTree == false)
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
            SpawningTree = false;
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.collider.gameObject.tag);
                GameObject obj = Instantiate(Tree, new Vector3(hit.point.x, 1.1f, hit.point.z), Quaternion.identity) as GameObject;
                gameManager.GetComponent<Inventory>().Materials -= 2;
                SpawningTree = false;
            }
        }
        else
        {

        }
    }
}
