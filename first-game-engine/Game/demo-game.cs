using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engine.Engine;
using System.Windows.Forms.Design;
namespace Engine
{
     class demo_game : Engine.Engine
    {
        string[,] Map =
        {
            {"","g","g","","","g","","","g","","","g","","","g","g","","" },
            { "g","","","g","","g","","g","g","g","","g","","g","","","g","" },
            { "g","","","g","","g","","g","","g","","g","","g","","","g","" },
             {"g","","","g","","","g","","","","g","","","g","","","g","" },
            {"","g","g","","","","","","","","","","","","g","g","","" },
            {".",".","",".",".",".",".",".",".","","","","","","","","","" },
        };


        //Sprite2D player;
        //Sprite2D player2;

       
        public demo_game() : base(new Vector2(865, 290), "demo" ){ }

        public override void OnLoad()
        {
            Console.WriteLine("Yay On load Works");
            backgroundColour = Color.Black;
            //player = new Shape2D(new Vector2(100, 100), new Vector2(100, 100), "Test");
            //player = new Sprite2D(new Vector2(10, 10), new Vector2(75, 75), "potato.png", "Player");

            for (int i = 0; i < Map.GetLength(1); i++) 
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j,i] == "g")
                    {
                        new Sprite2D(new Vector2(i*50, j*50), new Vector2(50, 50), "potato.png", "Ground");
                    }
                    
                }
            }
        }
        public override void OnDraw()
        {
            
        }

        int time = 0;
        float x = 1f;
        public override void OnUpdate()

        {
            //player.Position.X += x;
            //player.Position.Y += x;

            //player2.Position.X += x;
            //player2.Position.Y += x;

            //if (time > 100)
            //{
            //    if (player != null)
            //    {
            //        player.DestroySelf();
            //        player = null;

            //        player2.DestroySelf();
            //        player2 = null;

            //    }

            //}
            //if (time < 300)
            //{
            //    if (player == null)
            //    {
            //        player = new Sprite2D(new Vector2(10, 10), new Vector2(75, 75), "potato.png", "Player");
            //        player2 = new Sprite2D(new Vector2(200, 200), new Vector2(75, 75), "potato.png", "Player");

            //        time = 0;
            //    }

            //}
            //time++;
            


        }
    }
}
