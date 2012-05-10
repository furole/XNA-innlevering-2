using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Ponyquest.GameScreens;
using Microsoft.Xna.Framework;

namespace Ponyquest.Sprite_Classes
{
    public class Level
    {
        Texture2D Background;
        public Collision Collision;

        public Vector2 StartPosition = Vector2.Zero;
        public int StartAnimation = 0;

        public Level(Texture2D background, Texture2D collisionTexture, Vector2 startPosition, int startAnimation)
        {
            Background = background;
            Collision = new Collision(collisionTexture);

            StartPosition = startPosition;
            StartAnimation = startAnimation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
        }
    }
}
