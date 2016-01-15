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
                steamProfileURL += "games/?xml=1";

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

                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
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
