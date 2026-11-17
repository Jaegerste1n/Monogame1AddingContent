using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame1AddingContent
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Texture2D dinoTexture, houseTexture;
        Vector2 houseLocation;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            this.Window.Title = "Coagulate Gangrene Apotheosis Genesis 2003 Pecial Edition";
            
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            Random generator = new Random();
            int houseX = generator.Next(1, 400);
            int houseY = generator.Next(1, 300);
            houseLocation = new Vector2(houseX, houseY);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dinoTexture = Content.Load<Texture2D>("dino");
            houseTexture = Content.Load<Texture2D>("house");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            for (int i = 0; i < 4; i++)
            {
                int forY = i * 5;
                int forX = i * 200;
                _spriteBatch.Draw(houseTexture, new Vector2(forX, forY), Color.White);
            }
            _spriteBatch.Draw(houseTexture, new Vector2(300, 80), Color.White);
            _spriteBatch.Draw(dinoTexture, new Vector2(10, 100), Color.White);
            _spriteBatch.Draw(dinoTexture, new Vector2(20, 200), Color.Red);
            _spriteBatch.Draw(dinoTexture, new Vector2(30, 300), Color.Yellow);
            _spriteBatch.Draw(dinoTexture, new Vector2(40, 400), Color.Blue);
            
            _spriteBatch.Draw(houseTexture, houseLocation, Color.Red);
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
