using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Accessibility;

public class LogManager : MonoBehaviour 
{

    public static LogManager singleton;
    public string uuidParty;
    public List<Player> players = new List<Player>();
    public List<Building> DeckBuilding = new List<Building>();
    public List<Turn> Turns = new List<Turn>();
    public List<Role> Roles = new List<Role>();

    public int AttractScore;
    public int FluidScore;
    public int EnviScore;
    public int LogiScore;

    private void Awake()
    {
        if (singleton != null)
        {
            Debug.LogError("more than One LogManager");
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
    }


    public void SetUUID()
    {
        uuidParty = Guid.NewGuid().ToString();
    }

    public void GetPlayers()
    {

        players = GameManager.singleton.players;
    }


    public void GetDeckBuilding()
    {
        DeckBuilding = GameManager.singleton.game.DeckBuildings.ToList();
    }

    private void Start()
    {
        SetUUID();
        Roles = GameManager.singleton.game.Roles.ToList();
    }

    public List<Building> GetMarket()
    {
        return GameManager.singleton.game.Market.ToList(); 
    }

    public void GetScoreCity()
    {
        AttractScore = GameManager.singleton.game.cityAttractiveness;
        EnviScore = GameManager.singleton.game.cityEnvironment;
        FluidScore = GameManager.singleton.game.cityFluidity;
        LogiScore = GameManager.singleton.game.cityLogistic;
    }


    public void NewTurn()
    {
        Turns.Add(new Turn(GameManager.singleton.game.turnNumber, GetMarket()));
    }



    #region DatabaseManager

    public void SendInfo()
    {
        // Game
        StartCoroutine(SendGameInfos());

        //Player
        for (int i = 0; i < players.Count; i++)
        {
            StartCoroutine(SendPlayerInfo(players[i]));
        }

        //Roles
        for (int i = 0; i < Roles.Count; i++)
        {
            StartCoroutine(SendRoleInfo(Roles[i]));
        }
        //Buildings
        for (int i = 0; i < DeckBuilding.Count; i++)
        {
            StartCoroutine(SendBuildingInfo(DeckBuilding[i]));
        }

        //Bet and Turn
        for (int i = 0; i < Turns.Count-1; i++)
        {
            SendBetFromTurn(Turns[i]);
            StartCoroutine(SendTurnInfo(Turns[i]));
        }

    }
    IEnumerator SendGameInfos()
    {
        WWWForm infoGame = new WWWForm();
        infoGame.AddField("game_key", uuidParty);
        infoGame.AddField("nb_player", players.Count.ToString());
        infoGame.AddField("nb_buildings", GameManager.singleton.game.BuildingsBuilt.Count.ToString());
        infoGame.AddField("game_timer", 0.ToString());
        infoGame.AddField("turn_timer", 0.ToString());
        infoGame.AddField("envi_score", EnviScore.ToString());
        infoGame.AddField("attract_score", AttractScore.ToString());
        infoGame.AddField("fluid_score", FluidScore.ToString());
        infoGame.AddField("logi_score", LogiScore.ToString());
        infoGame.AddField("nb_turn", Turns.Count.ToString());
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinfogame.php", infoGame);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("GameUpload success");
        }
        else
        {
            Debug.Log("Game upload Failed");
        }
       
    }
    IEnumerator SendPlayerInfo(Player player)
    {
        WWWForm infoPlayer = new WWWForm();
        infoPlayer.AddField("game_key", uuidParty);
        infoPlayer.AddField("game_id", player.ID);
        infoPlayer.AddField("nom", player.namePlayer);
        infoPlayer.AddField("prenom", "xx");
        infoPlayer.AddField("sexe", "xx");
        infoPlayer.AddField("age", 0.ToString());
        infoPlayer.AddField("residence", "xx");
        infoPlayer.AddField("statut_activite", "xx");
        infoPlayer.AddField("job", "xx");
        infoPlayer.AddField("secteur_activite", "xx");
        infoPlayer.AddField("entreprise", "xx");
        infoPlayer.AddField("role", player.role.nameRole);
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinfoplayer.php", infoPlayer);
        
        yield return www;
        if (www.text == "0")
        {
            Debug.Log(player.namePlayer + "upload success");
        }
        else
        {
            Debug.Log("Player upload Failed");
        }

    }
    IEnumerator SendRoleInfo(Role role)
    {
        WWWForm infoRole = new WWWForm();
        infoRole.AddField("game_key", uuidParty);
        infoRole.AddField("name", role.nameRole);
        infoRole.AddField("social_tokens", role.ressourceSocial.ToString());
        infoRole.AddField("economical_tokens", role.ressourceEconomical.ToString());
        infoRole.AddField("political_tokens", role.ressourcePolitical.ToString());
        infoRole.AddField("hold", role.hold);
        infoRole.AddField("improve", role.improve);
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinforole.php", infoRole);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log(role.nameRole + "upload success");
        }
        else
        {
            Debug.Log("Role upload Failed");
        }

    }
    IEnumerator SendBuildingInfo(Building building)
    {
        WWWForm infoBuilding = new WWWForm();
        infoBuilding.AddField("game_key", uuidParty);
        infoBuilding.AddField("name", building.name);
        infoBuilding.AddField("description", building.description.ToString());
        infoBuilding.AddField("political_cost", building.Political.ToString());
        infoBuilding.AddField("economical_cost", building.Economical.ToString());
        infoBuilding.AddField("social_cost", building.Social.ToString());
        infoBuilding.AddField("attract_score", building.attractScore.ToString());
        infoBuilding.AddField("fluid_score", building.fluidScore.ToString());
        infoBuilding.AddField("envi_score", building.enviScore.ToString());
        infoBuilding.AddField("logi_score", building.logisticScore.ToString());
        infoBuilding.AddField("logi_description", building.logisticDescription);
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinfobuilding.php", infoBuilding);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log(building.name + "upload success");
        }
        else
        {
            Debug.Log("building upload Failed");
        }

    }

    public void SendBetFromTurn(Turn turn)
    {
        for (int i = 0; i < turn.Bets.Count; i++)
        {
            StartCoroutine(SendBetInfo(turn.Bets[i], turn.numTurn));
        }
    }

    IEnumerator SendBetInfo(Bet bet, int numTurn)
    {
        WWWForm infoBuilding = new WWWForm();
        infoBuilding.AddField("game_key", uuidParty);
        infoBuilding.AddField("player_id", bet.PlayerId);
        infoBuilding.AddField("political_bet", bet.politic.ToString());
        infoBuilding.AddField("social_bet", bet.social.ToString());
        infoBuilding.AddField("economical_bet", bet.econommical.ToString());
        infoBuilding.AddField("turn", numTurn.ToString());
        infoBuilding.AddField("building", bet.BuildingName);
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinfobet.php", infoBuilding);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Bet upload success");
        }
        else
        {
            Debug.Log("building upload Failed");
        }

    }

    IEnumerator SendTurnInfo(Turn turn)
    {
        WWWForm infoBuilding = new WWWForm();
        infoBuilding.AddField("game_key", uuidParty);
        infoBuilding.AddField("turn_number", turn.numTurn.ToString());
        infoBuilding.AddField("building_market_1", turn.Market[0].name);
        infoBuilding.AddField("building_market_2", turn.Market[1].name);
        infoBuilding.AddField("building_market_3", turn.Market[2].name);
        infoBuilding.AddField("building_market_4", turn.Market[3].name);
        infoBuilding.AddField("building_market_5", turn.Market[4].name);
        if(turn.BuildingBuild.Count >=1)
        {
            infoBuilding.AddField("building_completed_1", turn.BuildingBuild[0].name);
        }
        else
        {
            infoBuilding.AddField("building_completed_1", "");
        }
        if (turn.BuildingBuild.Count >= 2)
        {
            infoBuilding.AddField("building_completed_2", turn.BuildingBuild[1].name);
        }
        else
        {
            infoBuilding.AddField("building_completed_2", "");
        }
        if (turn.BuildingBuild.Count >= 3)
        {
            infoBuilding.AddField("building_completed_3", turn.BuildingBuild[2].name);
        }
        else
        {
            infoBuilding.AddField("building_completed_3", "");
        }
        if (turn.BuildingBuild.Count >= 4)
        {
            infoBuilding.AddField("building_completed_4", turn.BuildingBuild[3].name);
        }
        else
        {
            infoBuilding.AddField("building_completed_4", "");
        }
        if (turn.BuildingBuild.Count >= 5)
        {
            infoBuilding.AddField("building_completed_5", turn.BuildingBuild[4].name);
        }
        else
        {
            infoBuilding.AddField("building_completed_5", "");
        }

        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendinfoturn.php", infoBuilding);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Turn upload success");
        }
        else
        {
            Debug.Log("turn upload Failed");
        }
    }




    #endregion
}