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

namespace WindowsGame5
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player1 = new Player();

        List<Enemy> enemies = new List<Enemy>();
        Random random = new Random();

        public Game1()

        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 500;

            player1.Room_Height = graphics.PreferredBackBufferHeight;
            player1.Room_Width = graphics.PreferredBackBufferWidth;

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player1.position = new Vector2(400,200);

            

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
            player1.texture = Content.Load<Texture2D>("M");

          
            

            for (int i = 0; i < 10; i++)
            {
                
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        float spawn = 0;
        KeyboardState PastState = Keyboard.GetState();
        protected override void Update(GameTime gameTime)
        {

            KeyboardState KS = Keyboard.GetState();
            if(KS.IsKeyDown(Keys.P))
            {
                if (PastState.IsKeyUp(Keys.P))
                {

                }
            }
            LoadEnemies();

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

            player1.Update();

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(graphics.GraphicsDevice);
            }

            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int RandX = random.Next(0, player1.Room_Width - 76);

            if (spawn >= 1)
            {
                spawn = 0;
                if (enemies.Count < 8)
                {
                    enemies.Add(new Enemy(Content.Load<Texture2D>("N"), new Vector2(RandX, -300)));
                }

                for (int i = 0; i < enemies.Count; i++)
                    if (!enemies[i].isVisible)
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(player1.texture, player1.position, Color.White);

            foreach(Enemy enemy in enemies)
            enemy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
