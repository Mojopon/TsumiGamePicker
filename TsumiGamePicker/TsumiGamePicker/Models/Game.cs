using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;

namespace TsumiGamePicker.Models
{
    public class Game : NotificationObject
    {
        public string AppID { get; set; } = "";
        public string Name { get; set; } = "";
        public string StoreLink { get; set; }
        public string HoursOnRecord { get; set; } = "";
        public string Logo { get; set; } = "";
    }
}
