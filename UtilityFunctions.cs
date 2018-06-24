using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// This includes a number of utility methods for
    /// drawing and also some of them are used to to create game objects as well
    /// </summary>
    public static class UtilityFunctions
    {
        private static int i = 0;
		//
        // this checks if mouse on the rectangle
        public static bool IsMouseInRectangle (int x, int y, int w, int h)
        {
            Point2D mouse = default (Point2D);
            bool result = false;

            mouse = SwinGame.MousePosition ();

            //if the mouse is inline with the button horizontally
            if (mouse.X >= x & mouse.X <= x + w) {
                //Check vertical position
                if (mouse.Y >= y & mouse.Y <= y + h) {
                    result = true;
                }
            }

            return result;
        }
        //
        // simplay draws background
        public static void DrawBackGround(){
            Bitmap bitmap = GameResources.GameMenuBackgroundBitmap("cool");
            SwinGame.DrawBitmap(bitmap, 480, 0);
        }
        //
        /// <summary>
        /// creates an exploison objecjs 
        ///
        /// </summary>
        /// <param name="point2D">Point2 d.</param>
        public static void AddExplosion(Point2D point2D)
        {
            Bitmap bitmap = GameResources.GameExplosions ("explosion0");
            SwinGame.DrawBitmap (bitmap, point2D.X,point2D.Y);
        }
        //
        /// <summary>
        /// Draws the game data. 
        /// used to draw player health and player score
        /// </summary>
        // this is used tp 
        public static void DrawGameData(){
            SwinGame.DrawText ("your Score : ", Color.Gold, 600, 500);
            SwinGame.DrawText (Player.Score.ToString(), Color.Gold, 700, 500);
            SwinGame.DrawText ("Player Health: ", Color.Gold, 600, 530);
            PlayerManager playerManager = PlayerManager.GetInstance ();
            foreach (Player p in playerManager.PlayerList ()) {
                SwinGame.DrawRectangle (Color.White, 600, 550, 100, 10);
            SwinGame.FillRectangle (Color.Gold, 600, 550, p.Health, 10);
            }
        }
        //
        /// <summary>
        /// Draws the enmie health
        /// </summary>
        /// <param name="point2D">Point2D is enmies current location.</param>
        /// <param name="health" "enmie is current health uodates the rectangle">Health.</param>
        public static void DrawGameData(Point2D point2D, int health){
            SwinGame.DrawRectangle (Color.White, point2D.X, point2D.Y, 100, 10);
            SwinGame.FillRectangle (Color.Gold, point2D.X, point2D.Y, health, 10);
        }
        //
        /// <summary>
        /// Plaies the sound effects.
        /// </summary>
        /// <param name="name">Name.</param>
        //
        public static void PlaySoundEffects(string name)
        {
            SwinGame.PlaySoundEffect (GameResources.GameSound (name));
		}
         


        //
        // used to genreate random x and y location for enmey and powerups
        private static Point2D GetPoint2D ()
        {
            //
            //
            Random rnd = new Random ();
            Point2D point2D = new Point2D ();
            if (i % 2 == 0) {
                point2D.X = rnd.Next (60, 120);
            } else {
                point2D.X = rnd.Next (265, 345);
            }
            //
            point2D.X += 12;
            point2D.Y = rnd.Next (-300, -150);
            i++;
            return point2D;

        }
        //
        /// <summary>
        /// Creates the enmey object when called
        /// </summary>
        /// <returns>The enmey.</returns>
        public static Enmey CreateEnmey ()
        {
            Point2D point2D = new Point2D ();
            point2D = GetPoint2D ();
            return new Enmey (point2D);
        }
        //
        /// <summary>
        /// Creates the power ups when called
        /// </summary>
        /// <returns>The power ups.</returns>
        public static PowerUps CreatePowerUps ()
        {
            Point2D point2D = new Point2D ();
            point2D = GetPoint2D ();
            return new PowerUps (point2D);

        }
        //
        /// <summary>
        /// Creates the player bullets at player is locations
        /// </summary>
        /// <returns>The player bullets.</returns>
        public static PlayerBullet CreatePlayerBullets ()
        {
            Point2D point2D = new Point2D ();
            PlayerManager p= PlayerManager.GetInstance ();
            // returns list of player if they are more than one 
            // 
            List<Player> tempList = p.PlayerList ();
            foreach(Player c in tempList){
                point2D  =  c.Point2D;
            }
            point2D.X += 20;
            return new PlayerBullet (point2D);
        }
        //
        //
        /// <summary>
        /// Creates the enmie bullets.
        /// </summary>
        /// <returns>The enmie bullets.</returns>
        public static EnmeyBullet CreateEnmieBullets(){
            EnmeyBullet enmeyBullet = null;
            Point2D point2D = new Point2D ();
            List<Enmey> tempList = new List<Enmey> ();
            EnmeyManager enmeyManager = EnmeyManager.GetInstance ();
            tempList = enmeyManager.EnmieList ();
            foreach(Enmey e in tempList){
                point2D = e.Point2D;
                point2D.X += 40;
                point2D.Y += 200;
                enmeyBullet = new EnmeyBullet (point2D);
            }

            return enmeyBullet;
        }

        //
        //
        /// <summary>
        /// Creates the back ground for games playing state
        /// </summary>
        /// <returns>The back ground.</returns>
        public static Scene CreateBackGround(){
            Point2D point2D = new Point2D ();
            point2D.Y = -750;
            return new Scene (point2D);
        }

    }
}
