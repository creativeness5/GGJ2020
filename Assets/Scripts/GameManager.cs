using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Dictionary dictionary = null;

    public int OrganicMaterials = 0;

    public int Trees = 0;
    public int Animals = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj = this.gameObject;
        dictionary = this.GetComponent<Dictionary>();

        //dictionary.recipes.Add("aaaaaaa", );
    }

}
