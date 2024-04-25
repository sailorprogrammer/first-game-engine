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
        public demo_game() : base(new Vector2(512, 512), "demo" ){ }

        public override void OnLoad()
        {
            Console.WriteLine("Yay On load Works");
            backgroundColour = Color.Black;
            Shape2D player = new Shape2D(new Vector2(100, 100), new Vector2(100, 100), "Test");
            Shape2D player2 = new Shape2D(new Vector2(250, 100), new Vector2(100, 100), "Test2");
            Shape2D player3 = new Shape2D(new Vector2(175, 250), new Vector2(100, 100), "Test3");
        }
        public override void OnDraw()
        {
            
        }

        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"framecount{frame}");
            frame++;

        }
    }
}
