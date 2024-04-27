using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engine.Engine;
using System.Windows.Forms;
namespace Engine
{
     class demo_game : Engine.Engine
    {
       
        
        string[,] Map =
        {
            {"1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1" },
            {"1","","","","","1","1","1","1","1","1","1","","","","","","","","","","","","","1" },
            {"1","","","","","","","","","1","1","1","","","","","","","","","","","","","1" },
            {"1","","","","","","c","","","1","1","1","","","","","","","","","","","","","1" },
            {"1","","","1","1","c","c","","","1","1","1","","","","","","","","","","","","","1" },
            {"1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1","1" },
        };


        Sprite2D player;
        bool up;
        bool left;
        bool down;
        bool right;

        Vector2 LastPos = Vector2.Zero();
        public demo_game() : base(new Vector2(1275, 340), "demo" ){ }

        public override void OnLoad()
        {

            Console.WriteLine("Yay On load Works");
            
            backgroundColour = Color.Black;

            Sprite2D backwallref = new Sprite2D(new Vector2( 50,50), new Vector2(50, 50), "backwall.png", "backwall");
            Sprite2D potatoref = new Sprite2D(new Vector2(50, 50), new Vector2(50, 50), "potato.png", "potato");
            Sprite2D wallref = new Sprite2D(new Vector2(50, 50), new Vector2(50, 50), "wall.png", "wall");
        

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), backwallref, "backwall(ref)");
                    }

                }
            }
            player = new Sprite2D(new Vector2(50, 200), new Vector2(50, 50), potatoref, "potato(ref)");
          
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "1")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), wallref, "wall (ref)");
                    }
                    if (Map[j, i] == "c")
                    {
                        new Sprite2D(new Vector2(i* 50, j* 50), new Vector2(50, 50), "monz.png", "monz");
                    }
                }
            }




        }
        public override void OnDraw()
        {
            
        }

  
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
            Sprite2D monz = player.IsColliding("monz");
            if (monz != null)
            {
                monz.DestroySelf();
            }

                if (player.IsColliding("wall (ref)") != null)
            {
                player.Position.X = LastPos.X;
                player.Position.Y = LastPos.Y;
            }
            else
            {
                    LastPos.X = player.Position.X;
                    LastPos.Y = player.Position.Y;
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
