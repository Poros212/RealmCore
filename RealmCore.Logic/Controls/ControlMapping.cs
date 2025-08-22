using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Controls
{
    public static class ControlMapping
    {
        private static string _movementUP = "w";
        private static string _movementLEFT = "a";
        private static string _movementDOWN = "s";
        private static string _movementRIGHT = "d";
        private static string _exitMenu = "x";

        public static string MovementUP
        {
            get { return _movementUP; }
            set { _movementUP = value.ToLower(); }
        }

        public static string MovementLEFT
        {
            get { return _movementLEFT; }
            set { _movementLEFT = value.ToLower(); }
        }

        public static string MovementDOWN
        {
            get { return _movementDOWN; }
            set { _movementDOWN = value.ToLower(); }
        }

        public static string MovementRIGHT
        {
            get { return _movementRIGHT; }
            set { _movementRIGHT = value.ToLower(); }
        }

        public static string ExitMenu
        {
            get { return _exitMenu; }
            set { _exitMenu = value.ToLower(); }
        }
    }
}