﻿using Engine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine
{
    public class Shape2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Shape2D(Vector2 Position, Vector2 Scale,string Tag) 
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[SHAPE2D]({Tag}) - Has been Registered");
            Engine.RegisterShape(this);
        }
        public void DestroySelf()
        {
            Log.Info($"[SHAPE2D]({Tag}) - Has been Destroyed");
            Engine.UnRegisterShape(this);
        }
    }
}
