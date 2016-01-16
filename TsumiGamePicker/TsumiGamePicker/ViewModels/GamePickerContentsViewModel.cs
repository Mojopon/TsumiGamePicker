using Livet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsumiGamePicker.Models;
using TsumiGamePicker.Utility;
using TsumiGamePicker.Wrapper;

namespace TsumiGamePicker.ViewModels
{
    public class GamePickerContentsViewModel : ViewModel
    {
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


        #region GameInformationContent変更通知プロパティ
        private object _GameInformationContent;

        public object GameInformationContent
        {
            get
            { return _GameInformationContent; }
            set
            { 
                if (_GameInformationContent == value)
                    return;
                _GameInformationContent = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region SelectedGame変更通知プロパティ
        private string _SelectedGame;

        public string SelectedGame
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


        public GamePickerContentsViewModel()
        {
            GameListContent = new GameListViewModel();
            GameInformationContent = new GameInformationViewModel();

            SteamGameClient.Current.OnGameSelect.Subscribe(OnGameSelected);
        }

        void OnGameSelected(Game game)
        {

        }

        public void OnEnterURL(string url)
        {
            SteamGameClient.Current.UpdateGamesFromSteam(url);
        }
    }
}
