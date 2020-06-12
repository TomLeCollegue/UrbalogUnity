using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Game game = new Game();

    public List<Role> Roles { get; set; } = new List<Role>();

    private void Start()
    {
        game.FillMarket();
        game.FillDeckBuildings();
    }
}
