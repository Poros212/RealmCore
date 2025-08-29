using RealmCore.Logic.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotEnemy
    {
        public string Name { get; }
        public Character ChosenCharacter { get; }
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public Guid PlayerId { get; }
        public bool IsAlive { get; }
        public string TypeFlag { get; }

        public SnapshotEnemy(string name, Character chosenCharacter, int xCoordinate, int yCoordinate, Guid playerId, bool isAlive, string typeFlag)
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