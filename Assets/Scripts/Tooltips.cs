using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltips : MonoBehaviour
{
    public Text text;   // text object to change, for displaying the tooltip
    // Start is called before the first frame update

    // Sets the position of the textbox to just above the mouse position
    void Update()
    {
        transform.position = Input.mousePosition+ new Vector3(0, 65, 0);
    }
    // Sets the text of the tooltip textbox to a new string
    public void ChangeTooltipText(string newText)
    {
        text.text = newText;
    }

    // reverts the position of the tooltip so it does not interfere with another viewing of it
    public void RevertPosition()
    {
        transform.position = new Vector3(-700, 0, 0);
    }
}
