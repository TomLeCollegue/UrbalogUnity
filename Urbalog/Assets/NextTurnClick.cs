using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnClick : MonoBehaviour
{
    public void ClickNextTurn()
    {
        GameObject.Find("TurnManager").GetComponent<NextTurnButton>().ClickNextTurn();
    }
}
