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
        
        //Roles
        for (int i = 0; i < Roles.Count; i++)
        {
            SendRoleInfo(Roles[i]);
        }

        
        //Buildings
        for (int i = 0; i < DeckBuilding.Count; i++)
        {
            Debug.Log("On envoie " + DeckBuilding[i].name);
            SendBuildingInfo(DeckBuilding[i]);
        }

        

        //Bet and Turn
        for (int i = 0; i < Turns.Count - 1; i++)
        {
            SendBetFromTurn(Turns[i]);
            SendTurnInfo(Turns[i]);
        }

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
                        "'" + player.company + "'," +
                        "'" + player.role.nameRole + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }



    }
    void SendRoleInfo(Role role)
    {
       

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {

            conn.Open();

            string sql = "INSERT INTO roles (game_key, name, social_tokens, economical_tokens, political_tokens, hold, improve) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + role.nameRole + "'," +
                        "'" + role.ressourceSocial.ToString() + "'," +
                        "'" + role.ressourceEconomical.ToString() + "'," +
                        "'" + role.ressourcePolitical.ToString() + "'," +
                        "'" + role.hold + "'," +
                        "'" + role.improve + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }
    void SendBuildingInfo(Building building)
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {

            conn.Open();

            string sql = "INSERT INTO buildings (game_key, name, political_cost, social_cost, economical_cost, attract_score, fluid_score, envi_score, logi_score) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + building.name + "'," +
                        "'" + building.Political.ToString() + "'," +
                        "'" + building.Social.ToString() + "'," +
                        "'" + building.Economical.ToString() + "'," +
                        "'" + building.attractScore.ToString() + "'," +
                        "'" + building.fluidScore.ToString() + "'," +
                        "'" + building.enviScore.ToString() + "'," +
                        "'" + building.logisticScore.ToString() + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }





    }

    public void SendBetFromTurn(Turn turn)
    {
        for (int i = 0; i < turn.Bets.Count; i++)
        {
            SendBetInfo(turn.Bets[i], turn.numTurn);
        }
    }

    void SendBetInfo(Bet bet, int numTurn)
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


        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {

            conn.Open();

            string sql = "INSERT INTO bet_history (game_key, player_id, political_bet, social_bet, economical_bet, turn, building, created_at) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + bet.PlayerId + "'," +
                        "'" + bet.politic.ToString() + "'," +
                        "'" + bet.social.ToString() + "'," +
                        "'" + bet.econommical.ToString() + "'," +
                        "'" + numTurn.ToString() + "'," +
                        "'" + bet.BuildingName + "'," +
                        "'" + bet.dateTime + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }



    void SendTurnInfo(Turn turn)
    {

        List<String> buildingBuilt = new List<String>();
        if (turn.BuildingBuild.Count >= 1)
        {
            buildingBuilt.Add(turn.BuildingBuild[0].name);
        }
        else
        {
            buildingBuilt.Add("");
        }
        if (turn.BuildingBuild.Count >= 2)
        {
            buildingBuilt.Add(turn.BuildingBuild[1].name);
        }
        else
        {
            buildingBuilt.Add("");
        }
        if (turn.BuildingBuild.Count >= 3)
        {
            buildingBuilt.Add(turn.BuildingBuild[2].name);
        }
        else
        {
            buildingBuilt.Add("");
        }
        if (turn.BuildingBuild.Count >= 4)
        {
            buildingBuilt.Add(turn.BuildingBuild[3].name);
        }
        else
        {
            buildingBuilt.Add("");
        }
        if (turn.BuildingBuild.Count >= 5)
        {
            buildingBuilt.Add(turn.BuildingBuild[4].name);
        }
        else
        {
            buildingBuilt.Add("");
        }

       

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {

            conn.Open();

            string sql = "INSERT INTO turn_history (game_key, turn_number, building_market_1, building_market_2, building_market_3, building_market_4, building_market_5, building_completed_1, building_completed_2, building_completed_3,building_completed_4, building_completed_5, created_at) VALUES (" +
                        "'" + uuidParty + "'," +
                        "'" + turn.numTurn.ToString() + "'," +
                        "'" + turn.Market[0].name + "'," +
                        "'" + turn.Market[1].name + "'," +
                        "'" + turn.Market[2].name + "'," +
                        "'" + turn.Market[3].name + "'," +
                        "'" + turn.Market[4].name + "'," +
                        "'" + buildingBuilt[0] + "'," +
                        "'" + buildingBuilt[1] + "'," +
                        "'" + buildingBuilt[2] + "'," +
                        "'" + buildingBuilt[3] + "'," +
                        "'" + buildingBuilt[4] + "'," + 
                        "'" + turn.dateTime + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }
    #endregion
}