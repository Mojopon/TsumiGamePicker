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


        public GameListViewModel(GamePickerContentsViewModel parent)
        {
            Games = parent.Games;
        }

        public void Initialize()
        {
        }
    }
}
