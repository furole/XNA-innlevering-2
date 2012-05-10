using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ponyquest.Sprite_Classes
{
    public class Player
    {
        public Sprite Sprite;
        public Vector2 Position = new Vector2(640, 700);

        public Player(Sprite sprite)
        {
            Sprite = sprite;
        }

        public void Update(float deltaTime, Ponyquest.GameScreens.Collision collision)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Boolean moving = false;
            float multiplier = 1f;
            Vector2 desiredPosition = Position;

            if (keyboardState.IsKeyDown(Keys.Space))
                multiplier = 2f;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Sprite.AnimationId = 1;
                moving = true;
                desiredPosition.X -= 100f * deltaTime * multiplier;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Sprite.AnimationId = 2;
                moving = true;
                desiredPosition.X += 100f * deltaTime * multiplier;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Sprite.AnimationId = 3;
                moving = true;
                desiredPosition.Y -= 100f * deltaTime * multiplier;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                Sprite.AnimationId = 0;
                moving = true;
                desiredPosition.Y += 100f * deltaTime * multiplier;
            }

            //If the sprite is moving, and the desired location is valid, we move it and update animation
            if ((moving) && (!collision.DoesCollide(desiredPosition)))
            {
                Position = desiredPosition;
                Sprite.UpdateAnimation(deltaTime * multiplier);
            }
            else
                Sprite.FrameIndex = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.DrawAtPosition(ref Position, spriteBatch);
        }
    }
}
