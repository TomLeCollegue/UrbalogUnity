using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCreateTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateTablesBet();
        CreateTablesBuildings();
        CreateTablesGames();
        CreateTablesPlayers();
        CreateTablesRoles();
        CreateTablesTurnHistory();
        //testMySQL();
    }


    //test function not used
    void testMySQL()
    {
        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            System.Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "INSERT INTO testurba (name,age) VALUES ('Tom', '12')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }


    void CreateTablesBet()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS `bet_history` ( "+ 
            "`id` int(255) NOT NULL AUTO_INCREMENT," +
            "`game_key` varchar(255) NOT NULL," +
            "`player_id` varchar(255) NOT NULL," +
            "`political_bet` varchar(255) NOT NULL," +
            "`social_bet` varchar(255) NOT NULL," +
            "`economical_bet` varchar(255) NOT NULL," +
            "`turn` varchar(255) NOT NULL," + 
            "`building` varchar(255) NOT NULL," + 
            "`created_at` text NOT NULL," +
            "PRIMARY KEY(`id`)" +
            ") ENGINE = InnoDB AUTO_INCREMENT = 182 DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }

    void CreateTablesBuildings()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS `buildings` (" +
                         "`id` int(255) NOT NULL AUTO_INCREMENT," +
                         "`game_key` varchar(255) NOT NULL," +
                         "`name` varchar(255) NOT NULL," +
                         "`political_cost` varchar(255) NOT NULL," +
                         "`social_cost` varchar(255) NOT NULL," +
                         "`economical_cost` varchar(255) NOT NULL," +
                         "`attract_score` varchar(255) NOT NULL," +
                         "`fluid_score` varchar(255) NOT NULL," +
                         "`envi_score` varchar(255) NOT NULL," +
                         "`logi_score` varchar(255) NOT NULL," +
                         "PRIMARY KEY(`id`)" +
                         ") ENGINE = InnoDB AUTO_INCREMENT = 325 DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }

    void CreateTablesGames()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE `games` (" +
                        "`id` int(255) NOT NULL AUTO_INCREMENT," +
                        "`game_key` varchar(255) NOT NULL," +
                        "`nb_players` varchar(255) NOT NULL," +
                        "`nb_buildings` varchar(255) NOT NULL," +
                        "`nb_buildings_per_turn` varchar(255) NOT NULL," +
                        "`game_timer` varchar(255) NOT NULL," +
                        "`turn_timer` varchar(255) NOT NULL," +
                        "`score_fuild` varchar(255) NOT NULL," +
                        "`score_attract` varchar(255) NOT NULL," +
                        "`score_envi` varchar(255) NOT NULL," +
                        "`score_logi` varchar(255) NOT NULL," +
                        "`nb_turn` varchar(255) NOT NULL," +
                        "PRIMARY KEY(`id`)" +
                       ") ENGINE = InnoDB AUTO_INCREMENT = 19 DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }


    void CreateTablesPlayers()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS `players` (" +
                        "`id` int(255) NOT NULL AUTO_INCREMENT," +
                        "`game_keys` varchar(255) NOT NULL," +
                        "`game_id` varchar(255) NOT NULL," +
                        "`nom` varchar(255) NOT NULL," +
                        "`firstname` varchar(255) NOT NULL," +
                        "`sexe` varchar(255) NOT NULL," +
                        "`age` varchar(255) NOT NULL," +
                        "`residence` varchar(255) NOT NULL," +
                        "`statut_activite` varchar(255) NOT NULL," +
                        "`job` varchar(255) NOT NULL," +
                        "`secteur_activite` varchar(255) NOT NULL," +
                        "`entreprise` varchar(255) NOT NULL," +
                        "`role_player` varchar(255) NOT NULL," +
                        "PRIMARY KEY(`id`)" +
                        ") ENGINE = InnoDB AUTO_INCREMENT = 19 DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }

    void CreateTablesRoles()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS `roles` ( "+
                        "`id` int(11) NOT NULL AUTO_INCREMENT," +
                        "`game_key` varchar(255) NOT NULL," +
                        "`name` varchar(255) NOT NULL," +
                        "`social_tokens` int(255) NOT NULL," +
                        "`economical_tokens` int(255) NOT NULL," +
                        "`political_tokens` int(255) NOT NULL," +
                        "`hold` varchar(255) NOT NULL," +
                        "`improve` varchar(255) NOT NULL," +
                        "PRIMARY KEY(`id`)" +
                        ") ENGINE = InnoDB AUTO_INCREMENT = 81 DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }

    void CreateTablesTurnHistory()
    {

        string connStr = "server=localhost;user=root;database=logurbalog;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS `turn_history` ("+
                        "`id` int(255)," +
                        "`game_key` varchar(255) NOT NULL," +
                        "`turn_number` int(255) NOT NULL," +
                        "`building_market_1` varchar(255) NOT NULL," +
                        "`building_market_2` varchar(255) NOT NULL," +
                        "`building_market_3` varchar(255) NOT NULL," +
                        "`building_market_4` varchar(255) NOT NULL," +
                        "`building_market_5` varchar(255) NOT NULL," +
                        "`building_completed_1` varchar(255) NOT NULL," +
                        "`building_completed_2` varchar(255) NOT NULL," +
                        "`building_completed_3` varchar(255) NOT NULL," +
                        "`building_completed_4` varchar(255) NOT NULL," +
                        "`building_completed_5` varchar(255) NOT NULL," +
                        "`created_at` text NOT NULL" +
                        ") ENGINE = InnoDB DEFAULT CHARSET = latin1";


            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }




}
