using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Accessibility;
using MySql.Data.MySqlClient;

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
    public string dateTime;

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
        dateTime = DateTime.Now.ToString();
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
        Debug.Log("On envoie les log");
        SendGameInfos();

        //Player
        for (int i = 0; i < players.Count; i++)
        {
            Debug.Log("On envoie les players");
            SendPlayerInfo(players[i]);
        } 
        /*
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
        for (int i = 0; i < Turns.Count - 1; i++)
        {
            SendBetFromTurn(Turns[i]);
            StartCoroutine(SendTurnInfo(Turns[i]));
        }*/

    }
    void SendGameInfos()
    {
        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            
            conn.Open();

            string sql = "INSERT INTO games (game_key, nb_players, nb_buildings,nb_buildings_per_turn, game_timer, turn_timer, score_fuild, score_attract, score_envi, score_logi, nb_turn) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + players.Count.ToString() + "'," +
                        "'" + GameManager.singleton.game.BuildingsBuilt.Count.ToString() + "'," +
                        "'" + GameSettings.nbBuildingsPerTurn.ToString() + "'," +
                        "'" + GameSettings.GameTimerMax.ToString() + "'," +
                        "'" + GameSettings.TurnTimeMax.ToString() + "'," +
                        "'" + FluidScore.ToString() + "'," +
                        "'" + AttractScore.ToString() + "'," +
                        "'" + EnviScore.ToString() + "'," +
                        "'" + LogiScore.ToString() + "'," +
                        "'" + (Turns.Count - 1 ).ToString() + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
    void SendPlayerInfo(Player player)
    {
        /*WWWForm infoPlayer = new WWWForm();
        infoPlayer.AddField("game_key", uuidParty);
        infoPlayer.AddField("game_id", player.ID);
        infoPlayer.AddField("nom", player.playerFamilyName);
        infoPlayer.AddField("prenom", player.namePlayer);
        infoPlayer.AddField("sexe", player.gender);
        infoPlayer.AddField("age", player.age);
        infoPlayer.AddField("residence", player.zipcode);
        infoPlayer.AddField("statut_activite", player.jobStatus);
        infoPlayer.AddField("job", player.jobStatus);
        infoPlayer.AddField("secteur_activite", player.field);
        infoPlayer.AddField("entreprise", player.company);
        infoPlayer.AddField("role", player.role.nameRole);*/

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {

            conn.Open();

            string sql = "INSERT INTO players (game_keys, game_id, nom, firstname, sexe, age, residence, statut_activite, job,secteur_activite,entreprise,role_player) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + player.ID + "'," +
                        "'" + player.playerFamilyName + "'," +
                        "'" + player.namePlayer + "'," +
                        "'" + player.gender + "'," +
                        "'" + player.age + "'," +
                        "'" + player.zipcode + "'," +
                        "'" + player.jobStatus + "'," +
                        "'" + player.jobStatus + "'," +
                        "'" + player.field + "'," +
                        "'" + player.company + ",)" +
                        "'" + player.role.nameRole + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
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
        infoBuilding.AddField("created_at", bet.dateTime);
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
        infoBuilding.AddField("created_at", turn.dateTime);
        if (turn.BuildingBuild.Count >= 1)
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



    public void getLog()
    {
        // Game
        StartCoroutine(GetAllLOG());
    }
    IEnumerator GetAllLOG()
    {
        WWW www = new WWW("http://89.87.13.28:8800/database/php_request_urba/sendInfoToServerUrbalog.php");
        yield return www;
        if (www.text != "0")
        {
            Debug.Log(www.bytes.ToString());
        }
        else
        {
            Debug.Log("Failed");
        }
    }
}