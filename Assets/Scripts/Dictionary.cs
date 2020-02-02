using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public Dictionary<string, string[]> recipes = new Dictionary<string, string[]>()
    {
        {"tree", new string[] {"organic", "organic"}},
        {"animal", new string[] {"organic", "organic", "organic"}},
    };
}