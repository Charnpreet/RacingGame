using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    /// <summary>
    /// this class manages all the powers in the game
    /// </summary>
    public class PowerUps: gameObject, ICollidableWith<Player>
    {
        Point2D point2D;
        Bitmap bitmap;
        int health;
        private PowerUpsKind boostKind;
        public PowerUps (Point2D point2D)
        {
            health = 100;
            this.point2D = point2D;
            boostKind = (PowerUpsKind)SwinGame.Rnd (9);
            bitmap = GameResources.GamePowerups (boostKind.ToString ());
        }
        /// <summary>
        /// Gets or sets the point2 d.
        /// </summary>
        /// <value>The point2 d.</value>
        public override Point2D Point2D {
            get {
                return point2D;
            }
            set {
                Point2D = value;
            }
        }
        //
        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        //
        public override Bitmap Bitmap {
            get {
                return bitmap;
            }

            set {
                bitmap = value;
            }

        }
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>The health.</value>
        public override int Health {
            get {
                return health;
            }
            set{
                health = value;
            }
        }

       
        /// <summary>
        /// Draw this instance on the screen
        /// </summary>
        public override void Draw ()
        {
            SwinGame.DrawBitmap (Bitmap, Point2D.X, Point2D.Y);
        }
        public override void Update ()
        {
            this.point2D.Y += 10;
            if(this.Point2D.X>SwinGame.ScreenHeight()){
                Health = 0;
            }
        }
        //
        /// <summary>
        /// Icollided the specified iCollidableList.
        /// it checks if any power has collidec with player 
        /// </summary>
        /// <returns>The icollided.</returns>
        /// <param name="iCollidableList">I collidable list is list of players.</param>
        public bool Icollided (List<Player> iCollidableList)
        {
            foreach (Player p in iCollidableList) {
                if (SwinGame.BitmapCollision (p.Bitmap, p.Point2D, Bitmap, Point2D)) {
                    p.Health += 10;
                    //
                    // play's sound upon collision
                    UtilityFunctions.PlaySoundEffects ("pick");
                    return true;
                }
            }
            return false;
        }
    }
}
