using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class ressource
    {

        //champs statics
        public static Texture2D Pikachu, Arbre, backimage, base_herbe, pelouse, jouer2;
        //Load content
        public static void Loadcontent(ContentManager content)
        {
            Pikachu = content.Load<Texture2D>("pikachu");
            Arbre = content.Load<Texture2D>("arbres10");
            backimage = content.Load<Texture2D>("pokemon");
            // Textures carte
            base_herbe = content.Load<Texture2D>("base_herbe");
            pelouse = content.Load<Texture2D>("pelouse");
            // Texture menu
            jouer2 = content.Load<Texture2D>("jouer2");
        }
    }
}
