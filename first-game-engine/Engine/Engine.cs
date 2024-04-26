﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using Engine.Engine;
namespace Engine.Engine
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    
    public abstract class Engine
    {
      

        private Vector2 screenSize = new Vector2(512,512);
        private string Title = "First Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        private static List<Shape2D> AllShapes = new List<Shape2D>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public Color backgroundColour = Color.Black;

        public Engine(Vector2 screenSize, string title)
        {
            Log.Info("Game is starting owo");
            this.screenSize = screenSize;
            this.Title = title;

            Window = new Canvas();
            Window.Size = new Size((int)this.screenSize.X, (int)this.screenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();
            Application.Run(Window);
        }
        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }
        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }
        public static void UnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        void GameLoop()
        {   
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker) delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch 
                {
                    Log.Error("Game is Booting or has been terminated D:");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
           Graphics g = e.Graphics;
           g.Clear(backgroundColour);

          foreach(Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }
            foreach (Sprite2D sprite in AllSprites)
            {
                g.DrawImage(sprite.Sprite,sprite.Position.X,sprite.Position.Y,sprite.Scale.X,sprite.Scale.Y);
            }


        }
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
