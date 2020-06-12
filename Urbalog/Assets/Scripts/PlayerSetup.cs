using Mirror;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        
        GameManager gm = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();

        // mettre le nom du player dans le player
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        _player.ID = _netID;
        gm.players.Add(_player);
    }

 

    private void OnDestroy()
    {
        GameManager _gm = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();
        _gm.UnRegisterPlayer(GetComponent<NetworkIdentity>().netId.ToString());
        Debug.Log("remove");
    }
}
