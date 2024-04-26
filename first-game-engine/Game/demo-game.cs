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
     
        Sprite2D player;
        public demo_game() : base(new Vector2(512, 512), "demo" ){ }

        public override void OnLoad()
        {
            Console.WriteLine("Yay On load Works");
            backgroundColour = Color.Black;
            //player = new Shape2D(new Vector2(100, 100), new Vector2(100, 100), "Test");
            player = new Sprite2D(new Vector2(10, 10), new Vector2(75, 75), "potato.png", "Player");
        }
        public override void OnDraw()
        {
            
        }

        int time = 0;
        float x = 1f;
        public override void OnUpdate()
        {
            player.Position.X += x;


        }
    }
}
