using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    public GameObject fog;
    public int MaterialsSpawned;
    public GameObject Material;
    private float MaterialSpawnHeight = 0.5f;

    public bool CanSpawnItem = false;

    private void Start()
    {
        MaterialsSpawned = Random.Range(2, 5);
        for (int i = 0; i < MaterialsSpawned; i++)
        {
            Vector3 newPosition = new Vector3(this.gameObject.transform.position.x, MaterialSpawnHeight, this.gameObject.transform.position.z);
            GameObject tempMaterialObject = Instantiate(Material, newPosition, Quaternion.identity) as GameObject;

            tempMaterialObject.transform.parent = this.transform;

            tempMaterialObject.name = transform.parent.name + " Material " + i;

            MaterialSpawnHeight += 0.25f;
        }
    }
}
