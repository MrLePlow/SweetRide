using System;

namespace Game1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>C:\Users\Utilisateur\Desktop\Sweet Ride\Game1\Game1\mapandobj.cs
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

