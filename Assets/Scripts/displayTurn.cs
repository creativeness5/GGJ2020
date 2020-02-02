using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayTurn : MonoBehaviour
{

    public int turnNumber = 0;

    public bool endTurn = false;

    private Text turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = GetComponent<Text>();
    }

    public void increment()
    {
        turnNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        turn.text = "Turn: " + turnNumber;
        endTurn = true;
    }
}
