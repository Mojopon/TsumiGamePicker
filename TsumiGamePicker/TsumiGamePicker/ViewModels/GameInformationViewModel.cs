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
    public class GameInformationViewModel : ViewModel
    {

        #region SelectedGame変更通知プロパティ
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
                RaisePropertyChanged();
            }
        }
        #endregion


        public GameInformationViewModel()
        {
            SteamGameClient.Current.OnGameSelect.Subscribe(OnGameSelected);
        }

        void OnGameSelected(Game game)
        {
            SelectedGame = game;
        }
    }
}
