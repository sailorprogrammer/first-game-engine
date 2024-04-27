using Engine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine.Engine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public string Directory = "";
        
        public Bitmap Sprite = null;
        public Sprite2D(Vector2 Position, Vector2 Scale, string Directory, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;
            Image tmp = Image.FromFile($@"assets/{Directory}");

            Bitmap sprite = new Bitmap(tmp, (int)this.Scale.X, (int)this.Scale.Y);
            Sprite = sprite;

            Log.Info($"[SPRITE2D]({Tag}) - Has been Registered");
            Engine.RegisterSprite(this);
        }
        public Sprite2D(Vector2 Position, Vector2 Scale,Sprite2D reference, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;
            Sprite = reference.Sprite;

            Log.Info($"[SPRITE2D]({Tag}) - Has been Registered");
            Engine.RegisterSprite(this);
        }
        public Sprite2D IsColliding(string tag)
        {
       
            //return false;
            foreach (Sprite2D b in Engine.AllSprites)
            {
                if ( b.Tag == tag)
                {
                    if (Position.X < b.Position.X + b.Scale.X &&
                        Position.X + Scale.X > b.Position.X &&
                        Position.Y < b.Position.Y + b.Scale.Y &&
                        Position.Y + Scale.Y > b.Position.Y)
                    {
                        return b;
                    }

                }
                
        
                
            }

            return null;
        }

        public void DestroySelf()
        {
            Log.Info($"[SPRITE2D]({Tag}) - Has been Destroyed");
            Engine.UnRegisterSprite(this);
        }

        internal bool IsColliding(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
