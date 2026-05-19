using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Urbano_WPF.Data
{
    class Config
    {
        string fileName = @"config.ini";
        string filePath;
        FileIniDataParser parser;
        IniData data;

        public IniData Data { get => data; }

        public Config()
        {
            filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            parser = new FileIniDataParser();
            data = parser.ReadFile(filePath);
        }

        public static string GetString(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return value;
        }

        public static int GetInt(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return int.Parse(value);
        }

        public static bool GetBool(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return bool.Parse(value);
        }

        public static double GetDouble(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return double.Parse(value);
        }

        public static decimal GetDecimal(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return decimal.Parse(value);
        }

        public static ushort GetUshort(string category, string key)
        {
            var config = new Config();
            string value = config.Data[category][key];
            return ushort.Parse(value);
        }
    }
}
