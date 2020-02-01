using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    public Canvas canvas;
    public Text detailsText;
    public string detailsNewText;
    public void ChangeText(string newText)
    {
        detailsText.text = newText;
    }
}
