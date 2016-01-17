using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TsumiGamePicker.Views;

namespace TsumiGamePicker
{
    public class WindowService
    {
        public static WindowService Current { get; } = new WindowService();

        public void OpenWindow(WindowType windowType)
        {
            switch(windowType)
            {
                case WindowType.MainWindow:
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    return;
                case WindowType.RandomGamePickupWindow:
                    var randomGamePickupWindow = new RandomGamePickupWindow();
                    randomGamePickupWindow.Show();
                    return;
            }
        }
    }

    public enum WindowType
    {
        MainWindow,
        RandomGamePickupWindow,
    }
}
