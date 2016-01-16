using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using TsumiGamePicker.Models;
using TsumiGamePicker.Utility;

namespace TsumiGamePicker.Wrapper
{
    public class SteamGameClient
    {
        #region singleton

        public static SteamGameClient Current { get; } = new SteamGameClient();

        #endregion

        private Games Games;
        readonly Subject<Game> _CurrentGame = new Subject<Game>();
        public IObservable<Game> OnGameSelect => this._CurrentGame.AsObservable();

        readonly Subject<Games> _CurrentGames = new Subject<Games>();
        public IObservable<Games> OnGamesUpdate => this._CurrentGames.AsObservable();

        private SteamGameClient()
        {
            Games = new Games();
        }

        public void UpdateGamesFromSteam(string url)
        {
            var games = SteamProfileLoader.TryGetGamesFromSteamProfile(url);

            if (games != null)
            {
                Games.Clear();
                foreach(Game game in games)
                {
                    Games.Add(game);
                }

                _CurrentGames.OnNext(Games);
            }
        }

        public void GameSelected(Game selectedGame)
        {

        }
    }
}
