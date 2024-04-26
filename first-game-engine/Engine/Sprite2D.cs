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
           Image tmp = Image.FromFile($@"..\..\{Directory}");

            Bitmap sprite = new Bitmap(tmp,(int)this.Scale.X,(int)this.Scale.Y);
            Sprite = sprite;

            Log.Info($"[SPRITE2D]({Tag}) - Has been Registered");
            Engine.RegisterSprite(this);
        }
        public void DestroySelf()
        {
            Log.Info($"[SPRITE2D]({Tag}) - Has been Destroyed");
            Engine.UnRegisterSprite(this);
        }
    }
}
