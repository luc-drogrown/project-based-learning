using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueGame.Interfaces;
using RogueSharp;

namespace RogueGame.Core
{
    public class Actor : IActor, IDrawable
    {
        //IActor
        public string Name { get; set; }
        public int Awareness { get; set; }

        //IDrawable
        public RLColor Color { get; set; }
        public char Symbol { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public void Draw ( RLConsole console, IMap map )
        {
            //don't draw actors in part of the map that haven't been explored
            if (!map.GetCell(x, y).IsExplored)
            {
                return;
            }

            //only draw the actor with the color and symbol when they are in field-of-view
            if (map.IsInFov(x, y))
            {
                console.Set(x, y, Color, Colors.FloorBackgroundFov, Symbol);
            }
            else
            {
                //when not in FOV draw normal floor
                console.Set(x, y, Colors.Floor, Colors.FloorBackground, '.');
            }
        }
    }
}
