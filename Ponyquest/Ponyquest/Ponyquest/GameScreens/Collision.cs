using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ponyquest.GameScreens
{
    public class Collision
    {
        Texture2D CollisionTexture;
        Color[] CollisionData;

        public Collision(Texture2D collisionTexture)
        {
            CollisionTexture = collisionTexture;
            CollisionData = new Color[CollisionTexture.Width * CollisionTexture.Height];
            CollisionTexture.GetData<Color>(CollisionData);
        }


        public Boolean DoesCollide(Vector2 position)
        {
            int index = (int)position.X + ((int)position.Y * CollisionTexture.Width);

            if ((index >= CollisionData.Length) || (index < 0)
                || (position.X < 0) || (position.Y < 0)
                || (position.X > CollisionTexture.Width) || (position.Y > CollisionTexture.Height))
                return true;

            if (CollisionData[index] == Color.Black)
                return true;
            else
                return false;
        }
    }
    
}
