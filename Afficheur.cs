using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Afficheur
    {
        //champs

        Player Localplayer;
        Carre carte;
        List<Wall> Walls;


        bool clickdown;
        // constructeur
        public Afficheur()
        {

            Localplayer = new Player(40, 40);
            carte = new Carre(32, 32);
            Walls = new List<Wall>();
            clickdown = false;
        }

        //méthodes

        //update&draw
        public void update(MouseState mouse, KeyboardState keyboard, Camera2d cam)
        {
            Localplayer.update(mouse, keyboard, Walls, cam);
            foreach (Wall wall in Walls)
            {
                wall.update(mouse, keyboard);
            }

            if (mouse.LeftButton == ButtonState.Pressed && !clickdown)
            {
                Walls.Add(new Wall(mouse.X, mouse.Y, ressource.Arbre, 32));
                clickdown = true;
            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                clickdown = false;
            }
        }

        public void drawCarte(SpriteBatch spritebatch)
        {
            carte.draw(spritebatch);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            Localplayer.draw(spriteBatch);

            foreach (Wall wall in Walls)
            {
                wall.draw(spriteBatch);
            }
        }
    }
}
