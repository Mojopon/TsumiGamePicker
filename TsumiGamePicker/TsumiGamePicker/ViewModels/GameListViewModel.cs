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
using System.Collections.ObjectModel;
using TsumiGamePicker.Utility;
using TsumiGamePicker.Wrapper;

namespace TsumiGamePicker.ViewModels
{
    public class GameListViewModel : ViewModel
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


        #region Game変更通知プロパティ
        private Game _SelectedGame;

        public Game SelectedGame
        {
            get
            { return _SelectedGame; }
            set
            { 
                if (_SelectedGame == value)
                    return;
                _SelectedGame = value;
                SteamGameClient.Current.GameSelected(_SelectedGame);
                RaisePropertyChanged();
            }
        }
        #endregion


        private LivetCompositeDisposable compositeDisposables = new LivetCompositeDisposable();
        public GameListViewModel()
        {
            Games = new ObservableCollection<Game>();

            compositeDisposables.Add(SteamGameClient.Current.OnGamesUpdate.Subscribe(OnUpdateGames));
        }

        public void OnUpdateGames(Games games)
        {
            Games.Clear();
            foreach(Game game in games)
            {
                Games.Add(game);
            }
        }

        public void Initialize()
        {
        }
    }
}
