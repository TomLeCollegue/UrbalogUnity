
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetButton : MonoBehaviour
{
    
    public void ChangeNumberButton(int _num)
    {
        Player player = GameObject.Find("playerLocal").GetComponent<Player>();
        player.CmdChangeNum();
        
    }
}
