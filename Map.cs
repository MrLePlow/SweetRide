using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class Carre // Les elements que l'on "collent" bout à bout pour former une jolie map sexy.
    {
        // Attributs
        Texture2D texture;
        Vector2 coordonnees;
        Rectangle hitbox3;

        private int[] constructor;


        public Carre(int posix, int posiy)
        {
            this.hitbox3 = new Rectangle(posix, posiy, 32, 32);
            this.texture = null;
            this.coordonnees = Vector2.Zero;
            //loadConstructor();
        }

        public Carre(Texture2D texture, Vector2 cords)
        {
            this.texture = texture;
            this.coordonnees = cords;
            //loadConstructor();
        }

        private void loadConstructor()
        {
            using (StreamReader reader = File.OpenText("TextFile1.txt"))
            {
                int n = Convert.ToInt32(reader.ReadLine());
                constructor = new int[n];

                string s = reader.ReadLine();
                for (int i = 0; i < n; ++i)
                    constructor[i] = Convert.ToInt32(s[i]);
            }
        }

        public Vector2 Coordonnees
        {
            get { return this.coordonnees; }
            set { this.coordonnees = value; }
        }



        // On affichage d'abord la longueur

        public void update(SpriteBatch sol)
        {
        }

        public void draw(SpriteBatch sol)
        {
            int[] constructor = new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1};
            //Taille 22 
            // 3 dimensions : texture, abscisse de la tuile, ordonnée de la tuile, le point 0 est en haut, les x orienté vers la droite et les y vers le bas.

            int hauteur = 22;   // a ne pas spécifier
            int largeur = 22;   // plus grand que la longueur du tableau !

            Carre[,] map = new Carre[hauteur, largeur]; // on laisse 2 dimensions au cas ou, futurs modifs...


            Texture2D carre = ressource.base_herbe;
            // Indice servant à dessiner une ligne de carrés
            int draw_line = 1;

            // On affiche la carte à partir de (0,0)
            Vector2 position = new Vector2(0.0f, 0.0f);

            // On affichage d'abord la longueur
            for (int l = 0; l < map.GetLength(0); l++)
            {
                // Puis la largeur de la map
                for (int larg = 0; larg < map.GetLength(1); larg++)
                {
                    map[l, larg] = new Carre(carre, position);
                    if ((constructor[larg] == 0))//&&(larg == l))
                        sol.Draw(ressource.pelouse, map[l, larg].Coordonnees, Color.White);
                    else
                        if (constructor[larg] == 1)
                            sol.Draw(ressource.base_herbe, map[l, larg].Coordonnees, Color.White);
                    // On incrémente la position pour la prochaine tile
                    position.X += (carre.Width / 2);
                    position.Y += (carre.Height / 2);
                }
                // Une fois la première ligne faite, on retourne à la case départ,
                // et on calcule la position de la ligne suivante
                position.X = -carre.Width / 2 * draw_line;
                position.Y = (carre.Height) / 2 * draw_line;
                draw_line++;
            }

        }
    }
}