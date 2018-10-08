﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp_Assignment2
{
    public class DatabaseConnector
    {

        private const string CS = "Server=.\\MY_TEST_INSTANCE; Database = WebApp; Trusted_Connection = True";
        private static DatabaseConnector instance;

        private DatabaseConnector() { }

        public static DatabaseConnector Inst
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnector();
                }
                return instance;
            }
        }

        public List<String> get5Searches(string search)
        {
            List<string> retList = new List<string>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                string query = "SELECT TOP 5 Title from Articles WHERE Title LIKE \'" + search + "%\' UNION SELECT Title FROM UpdatableNews WHERE Title LIKE \'" + search + "%\'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    retList.Add(reader.GetString(0).Trim());
                }
                reader.Close();
            }
            return retList;
        }

        public List<newsData> readNewsData(string path)
        {
            List<newsData> news = new List<newsData>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                news = JsonConvert.DeserializeObject<List<newsData>>(json);
            }
            return news;
        }

        public void saveNewsData(string path, newsData data, string user)
        {
            string CS = "Server=.\\MY_TEST_INSTANCE; Database = WebApp; Trusted_Connection = True";
            string cmdString = "UPDATE UpdatableNews Set [User]=@user, Title=@title, Text=@text, Image=@image";

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = cmdString;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@title", data.Title);
                    cmd.Parameters.AddWithValue("@text", data.Text);
                    cmd.Parameters.AddWithValue("@image", data.Image);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}