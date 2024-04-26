using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engine.Engine;
namespace Engine
{
     class demo_game : Engine.Engine
    {
        Shape2D player;
        public demo_game() : base(new Vector2(512, 512), "demo" ){ }

        public override void OnLoad()
        {
            Console.WriteLine("Yay On load Works");
            backgroundColour = Color.Black;
            player = new Shape2D(new Vector2(100, 100), new Vector2(100, 100), "Test");
            
        }
        public override void OnDraw()
        {
            
        }

        int frame = 0;
        float x = 1f;
        public override void OnUpdate()
        {
            Log.Info($"framecount{frame}");
            frame++;
            player.Position.X += x;
            player.Scale.X += x;
            player.Scale.Y += x;
        }
    }
}
