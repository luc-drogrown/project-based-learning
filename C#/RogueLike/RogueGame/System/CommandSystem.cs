using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueGame.Core;

namespace RogueGame.System
{
    public class CommandSystem
    {
        //return value is true is the player was able to move, false otherwise, if the player tried to move through a wall
        public bool MovePlayer(Direction direction)
        {
            int x = Game.Player.x;
            int y = Game.Player.y;

            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Game.Player.y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Game.Player.y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Game.Player.x - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Game.Player.x + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (Game.DungeonMap.SetActorPosition(Game.Player, x, y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
