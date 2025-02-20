﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hello_Game__Tutorial__LH
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 ballPosition;
        private Vector2 ballVelocity;
        private Texture2D ballTexture;

        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Flying Corn";
        }

        protected override void Initialize()
        {
            ballPosition = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 3
                );

            System.Random random = new System.Random();
            ballVelocity = new Vector2(
                (float)random.NextDouble(),
                (float)random.NextDouble()
                );
            ballVelocity.Normalize();
            ballVelocity *= 100;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("Cron");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ballPosition += (float)gameTime.ElapsedGameTime.TotalSeconds * ballVelocity;

            if (ballPosition.X < GraphicsDevice.Viewport.X ||
                ballPosition.X > GraphicsDevice.Viewport.Width - 64)
            {
                ballVelocity.X *= -1;
            }

            if (ballPosition.Y < GraphicsDevice.Viewport.Y ||
                ballPosition.Y > GraphicsDevice.Viewport.Height - 64)
            {
                ballVelocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
