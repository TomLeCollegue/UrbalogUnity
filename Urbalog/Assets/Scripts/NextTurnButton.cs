using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCityScore()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        _betControl.CmdUpdateCityScore();
    }
}
