using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

namespace Assets.Plugins
{
    public class Persistencia : MonoBehaviour
    {
        
        private static SqliteConnection con;

        private void Awake()
        {
            string path = Application.dataPath + "/Plugins/Players.s3db";
            string url = "URI=file:" + path;
            if (!File.Exists(path))
            {
                createDatabase(path);
            }
            con = new SqliteConnection(url);
        }

        private static void createDatabase(string path)
        {
            /*
             CREATE TABLE [Player] (
            [nume] VARCHAR(255)  PRIMARY KEY NULL,
            [puncte] INTEGER  NULL,
            [active] BOOLEAN  NULL
            );
             */

            SqliteConnection.CreateFile("Players.s3db");
            SqliteConnection m_dbConnection = new SqliteConnection("Data Source=Players.s3db;Version=3;");
            m_dbConnection.Open();
            string sql = "CREATE TABLE [Player] ( [nume] VARCHAR(255)  PRIMARY KEY NULL, [puncte] INTEGER NULL, [active] BOOLEAN NULL );";
            SqliteCommand command = new SqliteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();

            File.Copy("Players.s3db", path);
        }

        public static void addPlayer(Player p)
        {
            con.Open();
            if (!emptyBD())
            {
                deactivateAllPlayers();
            }
            string sql = "insert into Player (nume, puncte, active) values('" + p.Name + "', '" + p.Points + "', 1)";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
        }

        private static bool emptyBD()
        {
            bool empty = true;
            string sql = "select * from Player";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                empty = false;
            }
            reader.Close();
            return empty;
        }

        public static Player getActivePlayer()
        {
            con.Open();
            Player player = null;
            if (!emptyBD())
            {
                string sql = "select * from Player where active = 1";
                SqliteCommand command = new SqliteCommand(sql, con);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string num = reader.GetString(0);
                    int po = reader.GetInt32(1);
                    player = new Player(num, po);
                }
                reader.Close();
            }
            con.Close();
            return player;
        }

        public static void setPlayerActive(Player p)
        {
            con.Open();
            deactivateAllPlayers();
            string sql = "update Player set active = 1 where nume = '" + p.Name + "'";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
        }

        private static void deactivateAllPlayers()
        {
            string sql = "update Player set active = 0";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.ExecuteNonQuery();
        }

        public static Player getPlayer(string nume)
        {
            Player player = null;
            con.Open();
            string sql = "select * from Player where nume = '"+nume + "'";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string num = reader.GetString(0);
                int po = reader.GetInt32(1);
                player = new Player(num, po);
            }
            reader.Close();
            con.Close();
            return player;
        }

        public static List<Player> getAllPlayers()
        {
            List<Player> players = new List<Player>();
            con.Open();
            string sql = "select * from Player";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string num = reader.GetString(0);
                int po = reader.GetInt32(1);
                players.Add(new Player(num, po));
            }
            reader.Close();
            con.Close();
            return players;
        }

        public static void updatePoints(Player p, int points)
        {
            string sql = "update Player set puncte = puncte + " + points + " where nume = '" + p.Name + "'";
            con.Open();
            SqliteCommand command = new SqliteCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}

