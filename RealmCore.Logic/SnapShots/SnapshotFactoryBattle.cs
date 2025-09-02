using RealmCore.Logic.Battle;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Spells;
using RealmCore.Logic.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealmCore.Logic.SnapShots
{
    public static class SnapshotFactoryBattle
    {
        public static SnapshotBattleContext CreateSnapshotBattleContext(BattleContext ctx)
        {
            int x = ctx.BattleField.Width;
            int y = ctx.BattleField.Height;

            SnapshotTile[,] snapshotTiles = new SnapshotTile[x, y];

            for (int row = 0; row < x; row++)
            {
                for (int col = 0; col < y; col++)
                {
                    Tile tile = ctx.BattleField.TileArray[row, col];

                    SnapshotTerrain snapshotTerrain = new SnapshotTerrain
                        (
                            tile.Terrain.Name,
                            tile.Terrain.Description,
                            tile.Terrain.MovementCost,
                            tile.Terrain.IsWalkable,
                            tile.Terrain.TerrainImage,
                            tile.Terrain.Color
                        );

                    Guid? playerId = null;

                    if (tile.OccupyingPlayer != null)
                    {
                        playerId = tile.OccupyingPlayer.ActorId;
                    }

                    snapshotTiles[row, col] = new SnapshotTile
                        (
                            tile.XAxis,
                            tile.YAxis,
                            snapshotTerrain,
                            playerId
                        );
                }
            }

            List<SnapshotPlayer> snapshotPlayersList = new List<SnapshotPlayer>();
            List<SnapshotEnemy> snapshotEnemiesList = new List<SnapshotEnemy>();
            Dictionary<Guid, (int, int)> snapshotActorsDict = new Dictionary<Guid, (int, int)>();

            foreach (var player in ctx.Players)
            {
                SnapshotCharacter characterSnapshot = new SnapshotCharacter
                    (
                        player.ChosenCharacter.Name,
                        player.ChosenCharacter.MaxHealth,
                        player.ChosenCharacter.CurrentHealth,
                        player.ChosenCharacter.MaxMana,
                        player.ChosenCharacter.CurrentMana,
                        player.ChosenCharacter.Intelligence,
                        player.ChosenCharacter.Defense,
                        player.ChosenCharacter.Resistance,
                        player.ChosenCharacter.SpellPool,
                        player.ChosenCharacter.MaxMovementPoints,
                        player.ChosenCharacter.CurrentMovementPoints,
                        player.ChosenCharacter.Speed
                    );

                SnapshotPlayer playerSnapshot = new SnapshotPlayer
                    (
                        player.Name,
                        characterSnapshot,
                        player.XCoordinate,
                        player.YCoordinate,
                        player.ActorId,
                        player.IsAlive,
                        player.TypeFlag
                    );

                snapshotPlayersList.Add(playerSnapshot);
                snapshotActorsDict[player.ActorId] = (player.XCoordinate, player.YCoordinate);
            }

            foreach (var enemy in ctx.Enemies)
            {
                SnapshotCharacter characterSnapshot = new SnapshotCharacter
                    (
                        enemy.ChosenCharacter.Name,
                        enemy.ChosenCharacter.MaxHealth,
                        enemy.ChosenCharacter.CurrentHealth,
                        enemy.ChosenCharacter.MaxMana,
                        enemy.ChosenCharacter.CurrentMana,
                        enemy.ChosenCharacter.Intelligence,
                        enemy.ChosenCharacter.Defense,
                        enemy.ChosenCharacter.Resistance,
                        enemy.ChosenCharacter.SpellPool,
                        enemy.ChosenCharacter.MaxMovementPoints,
                        enemy.ChosenCharacter.CurrentMovementPoints,
                        enemy.ChosenCharacter.Speed
                    );

                SnapshotEnemy enemySnapshot = new SnapshotEnemy
                    (
                        enemy.Name,
                        characterSnapshot,
                        enemy.XCoordinate,
                        enemy.YCoordinate,
                        enemy.ActorId,
                        enemy.IsAlive,
                        enemy.TypeFlag
                    );

                snapshotEnemiesList.Add(enemySnapshot);
                snapshotActorsDict[enemy.ActorId] = (enemy.XCoordinate, enemy.YCoordinate);
            }

            SnapshotBattlefield snapshotBattleField = new SnapshotBattlefield
                (
                    ctx.BattleField.Width,
                    ctx.BattleField.Height,
                    snapshotTiles,
                    snapshotActorsDict
                );

            return new SnapshotBattleContext
                (
                    snapshotPlayersList,
                    snapshotEnemiesList,
                    snapshotBattleField,
                    ctx.Turn,
                    ctx.ActiveActorId
                );
        }
    }
}