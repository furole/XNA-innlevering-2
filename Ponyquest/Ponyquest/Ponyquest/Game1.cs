using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Ponyquest.GameScreens;
using Ponyquest.Sprite_Classes;

namespace Ponyquest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

<<<<<<< HEAD
        enum GameState { MainMenu, Credits, InGame, Pause, GameOver }
        GameState currentGameState = GameState.MainMenu;
=======
        Texture2D Background;

        SoundEffect Sound;
        
>>>>>>> origin/master

        KeyboardState keyBoardState;

        Player Player;

        Level Bedroom;
        Level Field;
        Level ActiveLevel;

        Button btnPlay;
        Button btnCredits;
        Button btnBack;
        Button btnContinue;
        Button btnMainMenu;
        Button btnEndGame;
        Button btnExit;

        Rectangle BedroomExit = new Rectangle(5, 80, 720, 20);
        Rectangle FieldExit = new Rectangle(814, 343, 88, 24);

        int screenWidth = 1280, screenHeight = 720;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

          

            keyBoardState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Background = Content.Load<Texture2D>("room1");

            Sound = Content.Load<SoundEffect>("ambience_inside_hum");
            SoundEffectInstance soundEffectInstance = Sound.CreateInstance();
            Sound.Play();
            
            
            



            // TODO: use this.Content to load your game content here
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.ApplyChanges();
            IsMouseVisible = true;

            // Oppretter objekter for hver av menyknappene som skal være tilgjengelig - Kim
            btnPlay = new Button(Content.Load<Texture2D>(@"Content\Start_button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(470,250));
            btnCredits = new Button(Content.Load<Texture2D>(@"Content\CreditsButton"), graphics.GraphicsDevice);
            btnCredits.setPosition(new Vector2(470, 300));
            btnBack = new Button(Content.Load<Texture2D>(@"Content\BackButton"), graphics.GraphicsDevice);
            btnBack.setPosition(new Vector2(1100, 670));
            btnContinue = new Button(Content.Load<Texture2D>(@"Content\ContinueButton"), graphics.GraphicsDevice);
            btnContinue.setPosition(new Vector2(550, 400));
            btnMainMenu = new Button(Content.Load<Texture2D>(@"Content\MainMenuButton"), graphics.GraphicsDevice);
            btnMainMenu.setPosition(new Vector2(550, 450));
            btnEndGame = new Button(Content.Load<Texture2D>(@"Content\EndGameButton"), graphics.GraphicsDevice);
            btnEndGame.setPosition(new Vector2(550, 500));
            btnExit = new Button(Content.Load<Texture2D>(@"Content\ExitButton"), graphics.GraphicsDevice);
            btnExit.setPosition(new Vector2(550, 600));

            Sprite playerSprite = new Sprite(Content.Load<Texture2D>(@"Content\ponysheet"), 192, 192, 1f);

            Player = new Player(playerSprite);

            Bedroom = new Level(Content.Load<Texture2D>(@"Content\Bedroom"), Content.Load<Texture2D>(@"Content\BedroomCollision"),
                new Vector2(914, 539), 0);
            Field = new Level(Content.Load<Texture2D>(@"Content\FieldBackground"), Content.Load<Texture2D>(@"Content\BedroomCollision"),
                new Vector2(914, 539), 0);

            ActiveLevel = Bedroom;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // GameStates-updates håndteres her. - Kim
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) currentGameState = GameState.InGame;
                    btnPlay.Update(mouse);
                    if (btnCredits.isClicked == true) currentGameState = GameState.Credits;
                    btnCredits.Update(mouse);
                    break;

                case GameState.Credits:
                    if (btnBack.isClicked == true) currentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;

                case GameState.InGame:
                    if (keyBoardState.IsKeyDown(Keys.Escape)) currentGameState = GameState.Pause;
                    keyBoardState = Keyboard.GetState();
                    Player.Update(deltaTime, ActiveLevel.Collision);

                    Player.Update(deltaTime, ActiveLevel.Collision);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (ActiveLevel == Bedroom)
                {
                    if (BedroomExit.Contains((int)Player.Position.X, (int)Player.Position.Y))
                    {
                        ActiveLevel = Field;
                        Player.Position = ActiveLevel.StartPosition;
                        Player.Sprite.AnimationId = ActiveLevel.StartAnimation;
                    }
                }
                else if (ActiveLevel == Field)
                {
                    if (FieldExit.Contains((int)Player.Position.X, (int)Player.Position.Y))
                    {
                        ActiveLevel = Bedroom;
                        Player.Position = ActiveLevel.StartPosition;
                        Player.Sprite.AnimationId = ActiveLevel.StartAnimation;
                    }
                }
            }
                    break;

                case GameState.Pause:
                    if (btnContinue.isClicked == true) currentGameState = GameState.InGame;
                    btnContinue.Update(mouse);
                    if (btnMainMenu.isClicked == true) currentGameState = GameState.MainMenu;
                    btnMainMenu.Update(mouse);
                    if (btnEndGame.isClicked == true) currentGameState = GameState.GameOver;
                    btnEndGame.Update(mouse);
                    break;

                case GameState.GameOver:
                    if (btnExit.isClicked == true) this.Exit();
                    btnExit.Update(mouse);
                    break;
            }

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Gamestates draws håndteres her. - Kim
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>(@"Content\MainMenu"), new Rectangle(0,0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnCredits.Draw(spriteBatch);
                    break;

                case GameState.Credits:
                    spriteBatch.Draw(Content.Load<Texture2D>(@"Content\Credits"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnBack.Draw(spriteBatch);
                    break;

                case GameState.InGame:
                    ActiveLevel.Draw(spriteBatch);
                    Player.Draw(spriteBatch);
                    
                    break;

                case GameState.Pause:
                    spriteBatch.Draw(Content.Load<Texture2D>(@"Content\Paused"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnContinue.Draw(spriteBatch);
                    btnMainMenu.Draw(spriteBatch);
                    btnEndGame.Draw(spriteBatch);
                    break;

                case GameState.GameOver:
                    spriteBatch.Draw(Content.Load<Texture2D>(@"Content\GameOver"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnExit.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(Background, Vector2.Zero, Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
