using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using TsumiGamePicker.Models;
using TsumiGamePicker.Wrapper;

namespace TsumiGamePicker.ViewModels
{
    public class RandomGamePickupViewModel : ViewModel
    {

        #region Pickup変更通知プロパティ
        private string _Pickup;

        public string Pickup
        {
            get
            { return _Pickup; }
            set
            { 
                if (_Pickup == value)
                    return;
                _Pickup = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        private Games GameList = new Games();
        public RandomGamePickupViewModel()
        {

        }

        public void Initialize()
        {
            SteamGameClient.Current.OnGamesUpdate.Subscribe(UpdateGameList);
            Pickup = "Enter seed and Start!";
        }

        void UpdateGameList(Games games)
        {
            if (games.Count == 0) return;

            GameList.Clear();
            foreach(Game game in games)
            {
                GameList.Add(game);
            }
        }

        public void StartPickingUp(string seedText)
        {
            if (GameList.Count == 0)
            {
                Pickup = "You need to Load Profile First!";
                return;
            }

            Console.WriteLine(seedText);
            int seed = 0;
            for (int i = 0; i < seedText.Length; i++)
            {
                seed += seedText[i];
            }
            Console.WriteLine(seed);

            Random random = new Random(seed);
            Game pickupGame = GameList[random.Next(0, GameList.Count)];
            Pickup = pickupGame.Name;
            SteamGameClient.Current.SelectGame(pickupGame);
        }
    }
}
