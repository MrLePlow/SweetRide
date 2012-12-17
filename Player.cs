using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public enum direction
    {
        Up, Down, Left, Right // énumération des directions
    };
    class Player
    {
        // champs
        Rectangle hitbox;
        Rectangle hitbox2;
        direction direction; // indique la direction du perso
        Rectangle wallreducebox;
        Rectangle tmpbox;

        int frameline;
        int framecolumn;
        SpriteEffects effect;
        bool animation;
        int timer;

        int Speed = 3;
        int animationspeed = 10;

        // constructeurs
        public Player(int posx, int posy)
        {
            Console.WriteLine(posx);
            Console.WriteLine(posy);
            this.hitbox = new Rectangle(posx, posy, 25, 27);
            this.hitbox2 = new Rectangle((800 / 2) - 25, (454 / 2) - 27, 25, 27);



            this.frameline = 1; /*positionnement des */
            this.framecolumn = 2;/* frame sur l'image des prites*/
            this.direction = direction.Down; // met le personnage vers le bas, vers nous
            this.effect = SpriteEffects.None;
            this.animation = true;
            this.timer = 0;
        }


        //méthodes
        public void animate() // fonction qui permet d'animer les sprites en changeant l'état du rectangle contener sur l'image
        {
            this.timer++;
            if (this.timer == this.animationspeed)
            {
                this.timer = 0;
                if (this.animation)
                {
                    this.framecolumn++;
                    if (this.framecolumn > 3)
                    {
                        this.framecolumn = 2;
                        this.animation = false;
                    }
                }
                else
                {
                    this.framecolumn--;
                    if (this.framecolumn < 1)
                    {
                        this.framecolumn = 2;
                        this.animation = true;
                    }

                }
            }



        }

        //update&draw
        public void update(MouseState mouse, KeyboardState keyboard, List<Wall> walls, Camera2d cam)
        {

            tmpbox.Width = this.hitbox2.Width;
            tmpbox.Height = this.hitbox2.Height;

            if (keyboard.IsKeyDown(Keys.Up))
            {
                bool collide = false;

                //tmpbox = new Rectangle(this.hitbox2.X, this.hitbox2.Y + this.Speed, this.hitbox2.Width, this.hitbox2.Height);
                tmpbox.X = this.hitbox2.X;
                tmpbox.Y = this.hitbox2.Y - this.Speed;

                foreach (Wall wall in walls)
                {
                    wallreducebox.X = wall.hitbox.X + (int)(wall.hitbox.Width * 0.3f);
                    wallreducebox.Y = wall.hitbox.Y + (int)(wall.hitbox.Height * 0.3f);
                    wallreducebox.Width = (int)(wall.hitbox.Width * 0.2f);
                    wallreducebox.Height = (int)(wall.hitbox.Height * 0.2f);
                    if (tmpbox.Intersects(wallreducebox))
                    {
                        collide = true;
                        break;
                    }
                }


                if (!collide)
                    this.hitbox2.Y -= this.Speed;
                this.direction = direction.Up;
                this.animate();
            }
            else if (keyboard.IsKeyDown(Keys.Down))/* je met un else if pour éviter que le perso bouge en diagonale*/
            {
                bool collide = false;

                //tmpbox = new Rectangle(this.hitbox2.X, this.hitbox2.Y - this.Speed, this.hitbox2.Width, this.hitbox2.Height);
                tmpbox.X = this.hitbox2.X;
                tmpbox.Y = this.hitbox2.Y + this.Speed;

                foreach (Wall wall in walls)
                {
                    wallreducebox.X = wall.hitbox.X + (int)(wall.hitbox.Width * 0.3f);
                    wallreducebox.Y = wall.hitbox.Y + (int)(wall.hitbox.Height * 0.3f);
                    wallreducebox.Width = (int)(wall.hitbox.Width * 0.2f);
                    wallreducebox.Height = (int)(wall.hitbox.Height * 0.2f);
                    if (tmpbox.Intersects(wallreducebox))
                    {
                        collide = true;
                        break;
                    }
                }

                if (!collide)
                    this.hitbox2.Y += this.Speed;
                this.direction = direction.Down;
                this.animate();
            }
            else if (keyboard.IsKeyDown(Keys.Left))/* je met un else if pour éviter que le perso bouge en diagonale*/
            {
                bool collide = false;

                //tmpbox = new Rectangle(this.hitbox2.X - this.Speed, this.hitbox2.Y, this.hitbox2.Width, this.hitbox2.Height);
                tmpbox.X = this.hitbox2.X - this.Speed;
                tmpbox.Y = this.hitbox2.Y;

                foreach (Wall wall in walls)
                {
                    wallreducebox.X = wall.hitbox.X + (int)(wall.hitbox.Width * 0.3f);
                    wallreducebox.Y = wall.hitbox.Y + (int)(wall.hitbox.Height * 0.3f);
                    wallreducebox.Width = (int)(wall.hitbox.Width * 0.2f);
                    wallreducebox.Height = (int)(wall.hitbox.Height * 0.2f);
                    if (tmpbox.Intersects(wallreducebox))
                    {
                        collide = true;
                        break;
                    }
                }


                if (!collide)
                    this.hitbox2.X -= this.Speed;
                this.direction = direction.Left;
                this.animate();

            }
            else if (keyboard.IsKeyDown(Keys.Right))/* je met un else if pour éviter que le perso bouge en diagonale*/
            {
                bool collide = false;

                //tmpbox = new Rectangle(this.hitbox2.X + this.Speed, this.hitbox2.Y, this.hitbox2.Width, this.hitbox2.Height);
                tmpbox.X = this.hitbox2.X + this.Speed;
                tmpbox.Y = this.hitbox2.Y;

                foreach (Wall wall in walls)
                {
                    wallreducebox.X = wall.hitbox.X + (int)(wall.hitbox.Width * 0.3f);
                    wallreducebox.Y = wall.hitbox.Y + (int)(wall.hitbox.Height * 0.3f);
                    wallreducebox.Width = (int)(wall.hitbox.Width * 0.2f);
                    wallreducebox.Height = (int)(wall.hitbox.Height * 0.2f);
                    if (tmpbox.Intersects(wallreducebox))
                    {
                        collide = true;
                        break;
                    }
                }


                if (!collide)
                    this.hitbox2.X += this.Speed;
                this.direction = direction.Right;

                this.animate();

            }
            cam._pos.X = this.hitbox2.X;
            cam._pos.Y = this.hitbox2.Y;


            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down)
                && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right)) // permer de mettre le bon sprite à l'arrêt du perso
            {
                this.framecolumn = 2;
                this.timer = 0;
            }
            switch (this.direction)
            {
                case direction.Up: this.frameline = 2;
                    this.effect = SpriteEffects.None;
                    break;
                case direction.Down: this.frameline = 1;
                    this.effect = SpriteEffects.None;
                    break;
                case direction.Left: this.frameline = 3;
                    this.effect = SpriteEffects.None;
                    break;
                case direction.Right: this.frameline = 3;
                    this.effect = SpriteEffects.FlipHorizontally; // fait faire un tour au sprite pour le mettre de l'autre sens
                    break;
                /* permet de mettre les sprites de telle facon que les prites bougent dans les bonne directions*/

            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            //spritebatch.Draw(ressource.backimage, this.hitbox2, Color.White);
            spritebatch.Draw(ressource.Pikachu, this.hitbox2,
                new Rectangle((this.framecolumn - 1) * 25, (this.frameline - 1) * 27, 25, 27),
                Color.White, 0f, new Vector2(0, 0), this.effect, 0f);

        }
    }
}
