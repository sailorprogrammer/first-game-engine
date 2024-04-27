using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engine.Engine;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Media;
namespace Engine
{
     class demo_game : Engine.Engine
    {
       
        
        string[,] Map =
        {
            {"1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1" },
            {"1","","","","","","","","","","","","","","","","","","","","","","","","1" },
            {"1","","","","","","","","","","","","","","","","","","","","","","","","1" },
            {"1","","","","","","","","","","","","","","","","","","","","","","","","1" },
            {"1","","","","","","","","","","","","","","","","","","","","","","","","1" },
            {"1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1" },
        };


        Sprite2D player;
        bool up;
        bool left;
        bool down;
        bool right;

        public demo_game() : base(new Vector2(1275, 340), "demo" ){ }

        public override void OnLoad()
        {

            Console.WriteLine("Yay On load Works");
            
            backgroundColour = Color.Black;
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "backwall.png", "Background");
                    }

                }
            }
            player = new Sprite2D(new Vector2(50, 200), new Vector2(50, 50), "potato.png", "player");
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "1")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "wall.png", "Border");
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

            if (up)
            {
                player.Position.Y -= 3f;
            }
            if (left)
            {
                player.Position.X -= 3f;
            }
            if (down)
            {
                player.Position.Y += 3f;
            }
            if (right)
            {
                player.Position.X += 3f;
            }


        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            
        }
    }
}
