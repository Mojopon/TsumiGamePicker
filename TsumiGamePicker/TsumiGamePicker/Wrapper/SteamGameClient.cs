using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        readonly BehaviorSubject<Game> _SelectedGameGateway = new BehaviorSubject<Game>(null);
        public IObservable<Game> OnGameSelect => this._SelectedGameGateway.AsObservable();

        readonly BehaviorSubject<Games> _GameListGateway = new BehaviorSubject<Games>(null);
        public IObservable<Games> OnGamesUpdate => this._GameListGateway.AsObservable();

        private SteamGameClient()
        {
            Games = new Games();
            _GameListGateway.OnNext(Games);
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

                _GameListGateway.OnNext(Games);
            }
        }

        public void GameSelected(Game selectedGame)
        {
            _SelectedGameGateway.OnNext(selectedGame);
        }

        public ImageSource GetBanner(Game game)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(game.Logo, UriKind.Absolute);
            image.DecodePixelWidth = 180;
            image.EndInit();

            return image;
        }
    }
}
