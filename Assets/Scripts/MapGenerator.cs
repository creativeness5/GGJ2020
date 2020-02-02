using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{

    public int rows;
    public int columns;
    private float tileWidth = 1.0f;
    private float tileHeight = 1.0f;

    public GameObject[] TilePrefabs;

    Collider[] hitColliders;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float xPosition = tileWidth * j;
                float zPosition = tileHeight * i;
                Vector3 newPosition = new Vector3(xPosition, 0, zPosition);
                hitColliders = Physics.OverlapBox(newPosition, transform.localScale / 3);
                if (hitColliders.Length == 0)   // if there is nothing colliding with the hitColliders collider
                {
                    GameObject tempTileObj = Instantiate(RandomTile(), newPosition, Quaternion.identity) as GameObject;

                    tempTileObj.transform.parent = this.transform;

                    tempTileObj.name = "Tile " + j + ", " + i;
                    
                    Tile tempTile = tempTileObj.GetComponent<Tile>();
                }
            }
        }
    }

    private GameObject RandomTile() // grabs a random prefab
    {
        return TilePrefabs[Random.Range(0, TilePrefabs.Length)];
    }
}
