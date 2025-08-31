using RealmCore.Logic.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealmCore.Logic.SnapShots
{
    public sealed class SnapshotPlayer
    {
        public string Name { get; }
        public SnapshotCharacter ChosenCharacter { get; }
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public Guid PlayerId { get; }
        public bool IsAlive { get; }
        public string TypeFlag { get; }

        public SnapshotPlayer(string name, SnapshotCharacter chosenCharacter, int xCoordinate, int yCoordinate, Guid playerId, bool isAlive, string typeFlag)
        {
            Name = name;
            ChosenCharacter = chosenCharacter;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            PlayerId = playerId;
            IsAlive = isAlive;
            TypeFlag = typeFlag;
        }
    }
}