using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Ponyquest.Sprite_Classes
{
    public class Sprite
    {
        Texture2D SpriteSheet;

        Rectangle SourceRectangle = new Rectangle();

        Vector2 Offset;

        Boolean DirectionIsRight = true;

        int _FrameIndex = 0;
        public int FrameIndex
        {
            get
            {
                return _FrameIndex;
            }

            set
            {
                _FrameIndex = value;

                SourceRectangle.X = FrameIndex * SourceRectangle.Width;
            }
        }

        int FrameCount = 0;

        float _Duration = 1f;
        public float Duration
        {
            get
            {
                return _Duration;
            }

            set
            {
                _Duration = value;

                DurationPerFrame = (Duration / FrameCount) * 0.5f;
            }
        }

        float DurationPerFrame = 0.1f;
        float DurationCounter = 0f;

        int _AnimationId = 0;

        public int AnimationId
        {
            get
            {
                return _AnimationId;
            }

            set
            {
                _AnimationId = value;

                SourceRectangle.Y = _AnimationId * SourceRectangle.Height;
            }
        }

        public Sprite(Texture2D spriteSheet, int frameWidth, int frameHeight, float duration)
        {
            SpriteSheet = spriteSheet;
            SourceRectangle.Width = frameWidth;
            SourceRectangle.Height = frameHeight;

            FrameCount = SpriteSheet.Width / frameWidth;

            Duration = duration;

            Offset.X = frameWidth * 0.5f;
            Offset.Y = frameHeight;

            AnimationId = 2;
        }

        public void UpdateAnimation(float deltaTime)
        {
            DurationCounter += deltaTime;

            while (DurationCounter > DurationPerFrame)
            {
                DurationCounter -= DurationPerFrame;

                if (DirectionIsRight)
                {
                    FrameIndex++;

                    if (FrameIndex >= FrameCount)
                    {
                        FrameIndex = FrameCount - 2;
                        DirectionIsRight = false;
                    }
                }
                else
                {
                    FrameIndex--;

                    if (FrameIndex < 0)
                    {
                        FrameIndex = 1;
                        DirectionIsRight = true;
                    }
                }
            }
        }

        public void DrawAtPosition(ref Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, position - Offset, SourceRectangle, Color.White);
        }
    }
}
