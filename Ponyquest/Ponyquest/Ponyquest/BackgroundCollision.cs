using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyquest
{
    public class BackgroundCollision
    {
        Texture2D TextureCollision;
        Color[] CollisionData;

        public BackgroundCollision(Texture2D textureCollision)
        {
            TextureCollision = textureCollision;
            CollisionData = new Color[textureCollision.Width * textureCollision.Height];
            textureCollision.GetData<Color>(CollisionData);
        }

        public Boolean DoesCollide(Vector2 position)
        {
            int index = (int)position.X + ((int)position.Y * TextureCollision.Width);

            if (index >= CollisionData.Length)
                return true;
            if (index < 0)
                return true;
            if (position.X < 0)
                return true;
            if (position.Y < 0)
                return true;
            if (position.X > TextureCollision.Width)
                return true;
            if (position.Y > TextureCollision.Height)
                return true;

            if (CollisionData[index] == Color.Black)
                return true;
            else
                return false;
        }
       
    }
}
