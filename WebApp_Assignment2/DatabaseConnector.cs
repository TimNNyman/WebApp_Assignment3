﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp_Assignment2
{
    public class DatabaseConnector
    {
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

            return new List<string>() { search,"Hello world","These are static","Testing","A B C D E F G H I"};
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

        public void saveNewsData(string path, List<newsData> data)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
    }
}