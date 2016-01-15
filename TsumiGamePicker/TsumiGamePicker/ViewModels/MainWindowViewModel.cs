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
using System.Windows.Interactivity;
using System.Windows.Input;

namespace TsumiGamePicker.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        #region Content変更通知プロパティ
        private object _Content;
        public object Content
        {
            get
            { return _Content; }
            set
            { 
                if (_Content == value)
                    return;
                _Content = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public MainWindowViewModel()
        {
            Content = new GamePickerContentsViewModel();
        }
        public void Initialize()
        {
        }
    }
}
