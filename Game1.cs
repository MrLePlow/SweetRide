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

namespace Game1
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        MenuButton button1;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Camera2d m_cam; // Appelle la fonction Camera. 

        Afficheur class1;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;// permettre à la souris de s'afficher
            // graphics.IsFullScreen = true; // mettre en pleine écran
            m_cam = new Camera2d();
            m_cam.Move(new Vector2(400, 200));
        }


        protected override void Initialize()
        {
            button1 = new MenuButton(new Vector2(100, 200), Content.Load<Texture2D>("jouer2"), Content.Load<Texture2D>("jouer2"), new Rectangle(20, 20, 20, 20));
            base.Initialize();
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            DepthStencilState dst = new DepthStencilState();
            this.graphics.GraphicsDevice.DepthStencilState = dst;
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ressource.Loadcontent(Content);
            class1 = new Afficheur();



        }


        protected override void UnloadContent()
        {
            Content.Unload();

        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            class1.update(Mouse.GetState(), Keyboard.GetState(), m_cam);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        m_cam.get_transformation(GraphicsDevice));
      
            class1.drawCarte(spriteBatch);
            
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront,//On refait un spriteBatch.begin end pour que la map et la cam ne soit pas confondue
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        m_cam.get_transformation(GraphicsDevice));

            class1.draw(spriteBatch);
            button1.DrawButton(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
