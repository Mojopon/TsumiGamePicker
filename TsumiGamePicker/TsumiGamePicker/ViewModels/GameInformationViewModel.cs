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
        public GameInformationViewModel()
        {
            SteamGameClient.Current.OnGameSelect.Subscribe();
        }

        void OnGameSelected(Game game)
        {

        }

        public void Initialize()
        {
        }
    }
}
