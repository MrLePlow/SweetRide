using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Wall
    {
        //champs
        public Rectangle hitbox;
        Texture2D texture; // texture de l'objet


        //constructeurs
        public Wall(int x, int y, Texture2D texture, int size)
        {
            this.texture = texture; // définie les propriétés de texture
            this.hitbox = new Rectangle(x, y, size, size); // créé le rectangle pour la collision

        }

        //méthodes

        //update & draw
        public void update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.texture, this.hitbox, Color.White);

        }

    }
}
