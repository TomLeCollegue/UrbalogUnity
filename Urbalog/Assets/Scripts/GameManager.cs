using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Game game = new Game();

    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Player> players { get; set; } = new List<Player>();

    private void Start()
    {
        game.FillMarket();
        game.FillDeckBuildings();
    }


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));

        GUILayout.BeginVertical();

        for (int i = 0; i < players.Count; i++)
        {
            GUILayout.Label(players[i].ID);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    public void UnRegisterPlayer(string _ID)
    {
        players.RemoveAt(Int16.Parse(_ID));
    }
}
