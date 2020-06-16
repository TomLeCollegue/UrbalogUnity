using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNameRoom : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Awake()
    {
        HostGame hostgame = GameObject.Find("NetworkManager").GetComponent<HostGame>();
        text.text = hostgame.roomName;
    }
}
