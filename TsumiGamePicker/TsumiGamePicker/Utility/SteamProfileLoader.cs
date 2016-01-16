using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TsumiGamePicker.Models;

namespace TsumiGamePicker.Utility
{
    public static class SteamProfileLoader
    {

        public static List<Game> TryGetGamesFromSteamProfile(string steamProfileURL)
        {
            try {
                if (steamProfileURL[steamProfileURL.Length-1] != '/') steamProfileURL += "/";
                steamProfileURL += "games/?xml=1";

                if(!IsSteamProfileURL(steamProfileURL))
                {
                    Console.WriteLine("url is not valid");
                    return null;
                }

                Console.WriteLine("loading from " + steamProfileURL);

                XmlTextReader reader = new XmlTextReader(steamProfileURL);

                List<Game> games = new List<Game>();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "game")
                    {
                        games.Add(ParseElementsToGameClass(reader));
                    }
                }

                if (games.Count == 0) return null;

                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static readonly string steamCommunityURL = "http://steamcommunity.com/";
        private static readonly string[] steamProfileFolders = new string[]
        {
            "id/",
            "profiles/",
        };

        static bool IsSteamProfileURL(string url)
        {
            foreach(string folder in steamProfileFolders)
            {
                var host = steamCommunityURL + folder;
                if (host.Length > url.Length) continue;
                var hostInGivenURL = url.Substring(0, host.Length);
                if (hostInGivenURL.CompareTo(host) == 0) return true;
            }

            return false;
        }

        static Game ParseElementsToGameClass(XmlTextReader reader)
        {
            Game game = new Game();
            reader.Read();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    string readerName = reader.Name;
                    reader.Read();
                    switch (readerName)
                    {
                        case "appID":
                            {
                                game.AppID = reader.Value;
                            }
                            break;
                        case "name":
                            {
                                game.Name = reader.Value;
                            }
                            break;
                        case "logo":
                            {
                                game.Logo = reader.Value;
                            }
                            break;
                        case "storeLink":
                            {
                                game.StoreLink = reader.Value;
                            }
                            break;
                        case "hoursOnRecord":
                            {
                                game.HoursOnRecord = reader.Value;
                            }
                            break;
                    }
                }
                else if(reader.NodeType == XmlNodeType.EndElement)
                {
                    if (reader.Name == "game") return game;
                }

            }

            return null;
        }
    }
}
