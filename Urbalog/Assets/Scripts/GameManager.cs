
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

    public List<Player> players  = new List<Player>();

    private void Awake()
    {
        if (singleton != null)
        {
            Debug.LogError("more than One GameManager");
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }

        if (game.turnNumber<=1)
        {
            game.FillPiocheAtTheBeginning();
        }
            
        //game.FillDeckBuildings();
        game.FillMarket();
        game.FillRoles();

    }


    #region Registering players
    /// <summary>
    /// Remove a player from the player list when he disconnects.
    /// </summary>
    /// <param name="_ID">the id of the player leaving as a string</param>
    public void UnRegisterPlayer(string _ID)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if(players[i].ID.Equals(_ID))
            {
                players.Remove(players[i]);
            }
        }

        GameObject.Find("ListPlayerManager").GetComponent<FillListPlayer>().UpdateList();
    }

    /// <summary>
    /// Adds the player in the players list when he connects in the game as a client
    /// </summary>
    /// <param name="player">is a player Object. The player who just entered the game</param>
    public void RegisterPlayer(Player player)
    {
        players.Add(player);
        GameObject.Find("ListPlayerManager").GetComponent<FillListPlayer>().UpdateList();
    }

    #endregion

    /*/// <summary>
    /// Prints the players list on the lobby screen with their ID.
    /// </summary>
    void OnGUI()
    {
        if(SceneManager.GetActiveScene().name == "LobbyRoom") 
        {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));

        GUILayout.BeginVertical();

        for (int i = 0; i < singleton.players.Count; i++)
        {
            GUILayout.Label("Player "+ i + ": " + singleton.players[i].namePlayer);
        }
        
        GUILayout.EndVertical();
        GUILayout.EndArea();
        }
    }*/


   

}
