using Livet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsumiGamePicker.Models;
using TsumiGamePicker.Utility;

namespace TsumiGamePicker.ViewModels
{
    public class GamePickerContentsViewModel : ViewModel
    {

        #region Games変更通知プロパティ
        private ObservableCollection<Game> _Games;

        public ObservableCollection<Game> Games
        {
            get
            { return _Games; }
            set
            { 
                if (_Games == value)
                    return;
                _Games = value;
                RaisePropertyChanged();
            }
        }
        #endregion



        #region GameListContent変更通知プロパティ
        private GameListViewModel _GameListContent;

        public GameListViewModel GameListContent
        {
            get
            { return _GameListContent; }
            set
            { 
                if (_GameListContent == value)
                    return;
                _GameListContent = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public GamePickerContentsViewModel()
        {
            Games = new ObservableCollection<Game>();

            GameListContent = new GameListViewModel(this);
        }

        public void OnEnterURL(string url)
        {
            var games = SteamProfileLoader.TryGetGamesFromSteamProfile(url);

            if (games != null)
            {
                Games.Clear();
                foreach (Game game in games)
                {
                    Games.Add(game);
                }
            }
        }
    }
}
