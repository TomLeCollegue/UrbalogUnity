
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GameManager : MonoBehaviour
{

    public static GameManager singleton;

    public Game game = new Game();

    [SerializeField]
    public int NumPlayerForRole { get; set; } = 0;


    [SerializeField]
    private List<Player> players  = new List<Player>();

    private void Awake()
    {
        if (singleton != null)
        {
            Debug.LogError("more than One GameManager");
        }
        else
        {
            singleton = this;
        }

        game.FillMarket();
        game.FillDeckBuildings();
        game.FillRoles();
    }


    public void UnRegisterPlayer(string _ID)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if(players[i].ID.Equals(_ID))
            {
                players.Remove(players[i]);
            }
        }
    }

    
    public void RegisterPlayer(Player player)
    {
        players.Add(player);
    }

    public void ChangeValueNum()
    {
        game.Market[1].FinanceSocial += 1;
    }

    void OnGUI()
    {
        if(SceneManager.GetActiveScene().name == "LobbyRoom") 
        {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));

        GUILayout.BeginVertical();

        for (int i = 0; i < singleton.players.Count; i++)
        {
            GUILayout.Label("Player 1 : " + singleton.players[i].ID);
        }
        
        GUILayout.EndVertical();
        GUILayout.EndArea();
        }
    }

}
